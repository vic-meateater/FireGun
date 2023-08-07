using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DragWeaponSystem))]
public sealed class DragWeaponSystem : UpdateSystem
{
    private Filter _filter;
    private Camera _camera;
    private Transform _weaponTransform;

    public override void OnAwake()
    {
        _filter = World.Filter.With<WeaponHolderComponent>();
        foreach (var entity in _filter)
        {
            ref var weaponHolder = ref entity.GetComponent<WeaponHolderComponent>();

            _camera = weaponHolder.Camera;
            _weaponTransform = weaponHolder.Transform;
        }
    }

    public override void OnUpdate(float deltaTime)
    {

        //TODO: не работает 
        if (Touchscreen.current.primaryTouch.press.isPressed || Mouse.current.leftButton.isPressed)
        {
            Vector2 inputPosition = GetInputPosition();
            UpdateWeaponPosition(inputPosition, _camera, _weaponTransform);
        }
        
        
        // foreach (var entity in _filter)
        // {
        //     ref var weaponHolder = ref entity.GetComponent<WeaponHolderComponent>();
        //     
        //     var camera = weaponHolder.Camera;
        //     var weaponTransform = weaponHolder.Transform;
        //     
        //     if (Input.touchCount > 0)
        //     {
        //         //TODO: починить это
        //         Touch touch = Input.GetTouch(0);
        //         if (touch.phase == TouchPhase.Moved)
        //         {
        //             // Получаем позицию касания в мировых координатах
        //             Vector3 touchPosition =
        //                 camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
        //                     camera.nearClipPlane + 2.5f));
        //
        //             // Преобразуем координаты касания в нужный диапазон: X от -1 до 1, Y от -0.5 до 0.5
        //             float newX = Mathf.Clamp(touchPosition.x, -0.5f, 0.5f);
        //             float newY = Mathf.Clamp(touchPosition.y, 1f, 2f);
        //
        //             // Устанавливаем новую позицию оружия
        //             weaponTransform.position = new Vector3(touchPosition.x, touchPosition.y, touchPosition.z);
        //             //weaponTransform.position = touchPosition;
        //
        //         }
        //     }
        // }
        
    }
        private Vector2 GetInputPosition()
        {
            Vector2 inputPosition = Vector2.zero;

            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                // Получаем позицию касания для мобильного устройства
                inputPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            }
            else if (Mouse.current.leftButton.isPressed)
            {
                // Получаем позицию курсора для мыши
                inputPosition = Mouse.current.position.ReadValue();
            }

            return inputPosition;
        }
        
        private void UpdateWeaponPosition(Vector2 inputPosition, Camera camera, Transform weaponHolderTransform)
        {
            // Преобразуем координаты в мировые координаты
            Vector3 touchPosition = camera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y,
                camera.nearClipPlane + 2.5f));

            // Преобразуем координаты касания в нужный диапазон: X от -1 до 1, Y от -0.5 до 0.5
            float newX = Mathf.Clamp(touchPosition.x, -0.5f, 0.5f);
            float newY = Mathf.Clamp(touchPosition.y, -0.5f, 0.5f);

            // Устанавливаем новую позицию оружия
            weaponHolderTransform.position = new Vector3(newX, newY, touchPosition.z);
        }
}