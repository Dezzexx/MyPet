using System;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;
using Saver;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Client
{
#if UNITY_EDITOR
    [System.Serializable]
#endif
    public class GameState
    {
        private static GameState _gameState = null;

        public EcsSystems EcsSystems;
        public EcsWorld EcsWorld;

        public GameMode GameMode;
        public LayerMask
            FriendlyMask,
            EnemyMask,
            FriendlyAndEnemyMask,
            IgnoreRaycastMask,
            FriendlyBaseMask,
            GridCellMask,
            RideMask;

#region Input;
        public GraphicRaycaster Raycaster;
        public EventSystem EventSystem;
#endregion

#region Configs
        public SoundConfig SoundConfig;
        public GameConfig GameConfig;
        public PlayerConfig PlayerConfig;
        public LevelsConfig LevelsConfig;
        public InterfaceConfig InterfaceConfig;
        #endregion

        public AllPools AllPools;
        public AllPools ActivePools;

        public bool Sounds = true;
        public bool Music = true;
        public bool Vibration = true;

        public int PlayerResourceValue;
        public int SceneNumber, CurrentMaxBaseLVL = 1;

#region entity            
        public int LevelControllerEntity;
        public int InterfaceEntity;
        public int InputEntity;             // entity инпута
        public int SoundsEntity;            // entity звука
        public int VibrationEntity;                 
        public int CameraEntity;
        public int GridEntity;
        public int TutorialEntity;
        public const int NULL_ENTITY = -1;

        #endregion
        public int TutorialStage;
        public int LevelProgressIndex;  //индекс уровня, если уровни пошли по 2 кругу
        private GameState(in EcsStartup ecsStartup)
        {
            EcsWorld = ecsStartup.World;
            AllPools = ecsStartup.AllPools;
            SoundConfig = ecsStartup.SoundConfig;
            GameConfig = ecsStartup.GameConfig;
            PlayerConfig = ecsStartup.PlayerConfig;
            LevelsConfig = ecsStartup.LevelsConfig;
            InterfaceConfig = ecsStartup.InterfaceConfig;

            Load();
        }

        public static void Clear()
        {
            _gameState = null;
        }

        public static GameState Initialize(in EcsStartup ecsStartup)
        {
            if (_gameState is null)
            {
                _gameState = new GameState(in ecsStartup);
            }

            return _gameState;
        }

        public static GameState Get()
        {
            return _gameState;
        }

        #region Save
        public void Load()
        {
            var saver = new JsonSaver();
            SavedData data = saver.Load();

            Sounds = data.Sounds;
            Music = data.Music;
            Vibration = data.Vibration;
            PlayerResourceValue = data.PlayerResourceValue;
            SceneNumber = data.SceneNumber;
            TutorialStage = data.TutorialStage;
            LevelProgressIndex = data.LevelProgressIndex;

            //MinesCount = data.MinesCount < 0? GameConfig.MaximumBarricades: data.MinesCount;
            //MinesCoolDown = data.MinesCoolDown;
            //BarricadesCount = data.BarricadesCount < 0 ? GameConfig.MaximumMines : data.BarricadesCount;
            //BarricadesCooldown = data.BarricadesCooldown;
        }

        public void Save()
        {
            SavedData data = new SavedData();
            data.Sounds = Sounds;
            data.Music = Music;
            data.Vibration = Vibration;
            data.PlayerResourceValue = PlayerResourceValue;
            data.SceneNumber = SceneNumber;
            data.TutorialStage = TutorialStage;
            data.LevelProgressIndex = LevelProgressIndex;        

            var saver = new JsonSaver();
            saver.Save(data);
            Debug.Log("Save");
        }
        #endregion Save
    }

    public enum GameMode { beforePlay, play, win, lose }
}