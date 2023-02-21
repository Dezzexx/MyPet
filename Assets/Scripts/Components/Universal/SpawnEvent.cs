using UnityEngine;

namespace Client {
    struct SpawnEvent { 
        public SpawnTypes SpawnType;
        public Transform SpawnPositionTransform;
        public int XLineNumber;
        public int ObjectSpawnLvl;
        public Vector2Int GridPosition;
        public bool IsImmortality;
    }
    public enum SpawnTypes {FriendlyBaseOfUnits_new, EnemyBaseOfUnits, FrindlyUnit, EnemyUnit, FriendlyBaseOfUnits_merged };
}