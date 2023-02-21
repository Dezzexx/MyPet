namespace Client {
    struct AnimationSwitchEvent {
        public enum AnimationType
        {
            Idle, StayShoot, Win, DefaultRun, Defeat
        }
        public AnimationType AnimationSwitcher;
    }
}