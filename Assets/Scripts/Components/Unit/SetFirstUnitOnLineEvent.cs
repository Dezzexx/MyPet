namespace Client {
    struct SetFirstUnitOnLineEvent {
        public enum EventSpawnTypes {Friendly, Enemy, CalculateFriendlyNewFirst, CalculateEnemyNewFirst};
        public EventSpawnTypes EventSpawnType;
        public int LineNumber;
    }
}