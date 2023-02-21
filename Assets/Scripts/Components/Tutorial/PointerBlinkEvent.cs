using UnityEngine;

namespace Client {
    struct PointerBlinkEvent {
        //public RectTransform RectTransform;
        public Vector3 StartRect, EndRect;
        public bool isMergeTutorial;
        public int TapSpeed;
    }
}