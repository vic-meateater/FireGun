using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.UI;

public class UIEventHandler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private UIStartButtonClickedEventComponent _component;

    private void Awake()
    {
        _button.onClick.AddListener(() => OnButtonClick(_component.ButtonName));
    }

    private void OnButtonClick(string value)
    {
        Entity entity = World.Default.CreateEntity();
        ref var buttonClickedEvent = ref entity.AddComponent<UIStartButtonClickedEventComponent>();
        buttonClickedEvent.ButtonName = value;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => OnButtonClick(_component.ButtonName));
    }
}