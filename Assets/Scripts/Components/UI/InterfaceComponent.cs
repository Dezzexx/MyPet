using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace Client
{
    struct InterfaceComponent
    {
        public CanvasBehaviourMB CanvasBehaviour;
        public SettingsPanelBehaviourMB SettingsPanelBehaviour;
        public InGamePanelBehaviourMB InGamePanelBehaviour;
        public StorePanelBehaviourMB StorePanelBehaviour;
        public WinPanelBehaviourMB WinPanelBehaviour;
        public LosePanelBehaviourMB LosePanelBehaviour;
        public TutorialPanelBehaviourMB TutorialPanelBehaviour;
        public GeneralPanelBehaviourMB GenaralPanelBehaviourMB;
        public HealthbarMB HealthbarBehaviour;
        public GraphicRaycaster GraphicRaycaster;
        public PointerEventData PointerEventData;
        public EventSystem EventSystem;

    }
}