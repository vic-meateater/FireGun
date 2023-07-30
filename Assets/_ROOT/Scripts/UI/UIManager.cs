using System;
using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(Button))]
public class UIManager : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        //var name = _button.GetComponent<UIEventHandler>().buttonName;
        _button.onClick.AddListener(() => OnButtonClick(name));
    }

    private void OnButtonClick(string buttonName)
    {
        // В этом методе мы вызываем событие нажатия кнопки UI в Morpeh ECS
        // Создаем сущность с компонентом UIStartButtonClickedEventComponent и передаем информацию о нажатой кнопке
        Debug.Log("Click");
        Entity entity = World.Default.CreateEntity();
        ref var buttonClickedEvent = ref entity.AddComponent<UIStartButtonClickedEventComponent>();
        buttonClickedEvent.ButtonName = buttonName;
    }
}
