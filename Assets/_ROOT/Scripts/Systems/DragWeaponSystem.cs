using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DragWeaponSystem))]
public sealed class DragWeaponSystem : UpdateSystem
{
    private Filter _filter;

    public override void OnAwake()
    {
        _filter = World.Filter.With<WeaponHolderComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var weaponHolder = ref entity.GetComponent<WeaponHolderComponent>();
            
            var camera = weaponHolder.Camera;
            var weaponTransform = weaponHolder.Transform;
            
            if (Input.touchCount > 0)
            {
                //TODO: починить это
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    // Получаем позицию касания в мировых координатах
                    Vector3 touchPosition =
                        camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            camera.nearClipPlane + 2.5f));

                    // Преобразуем координаты касания в нужный диапазон: X от -1 до 1, Y от -0.5 до 0.5
                    float newX = Mathf.Clamp(touchPosition.x, -0.5f, 0.5f);
                    float newY = Mathf.Clamp(touchPosition.y, 1f, 2f);

                    // Устанавливаем новую позицию оружия
                    weaponTransform.position = new Vector3(touchPosition.x, touchPosition.y, touchPosition.z);
                    //weaponTransform.position = touchPosition;
                    
                    
                    Debug.Log(weaponTransform.position);
                }
            }
        }
    }
}