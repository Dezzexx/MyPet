using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;
using Client;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using Leopotam.EcsLite.Di;

public class WinPanelBehaviourMB : MonoBehaviour
{
    #region ECS
    private EcsWorld _world;
    private GameState _state;
    private EcsPool<ClickEvent> _clickPool;

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _holderWin;
    

    public void Init(EcsWorld world, GameState state)
    {
        _world = world;
        _state = state;
        _clickPool = _world.GetPool<ClickEvent>();
    }
    #endregion

    public void NextLevel()
    {
        _clickPool.Add(_world.NewEntity());

        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1)
        { 
        _state.SceneNumber = 3; }
        else
        {
            _state.SceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        }

        _state.LevelProgressIndex++;
        _state.Save();
        SceneManager.LoadScene(_state.SceneNumber);
    }

    public void StartWinEvent()
    {
        StartCoroutine(StartWin(1));
    }
    
    private IEnumerator StartWin(int value)
    {
        yield return new WaitForSeconds(value);
        // _leftConfetti.gameObject.SetActive(true);
        // _rigthConfetti.gameObject.SetActive(true);
        // _state.GameMode = GameMode.win;
        _holderWin.gameObject.SetActive(true);
        _holderWin.transform.DOMove(_target.position, value, false);
        //yield return new WaitForSeconds(value);
    }

    public Transform GetHolderWin()
    {
        return _holderWin;
    }
}
