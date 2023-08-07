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
    private Camera _camera;
    private Transform _weaponTransform;


    public override void OnAwake()
    {
        _filter = World.Filter.With<WeaponHolderComponent>().With<InputComponent>();
        foreach (var e in _filter)
        {
         ref var weaponHolder = ref e.GetComponent<WeaponHolderComponent>(); 
         _camera = weaponHolder.Camera;
         _weaponTransform = weaponHolder.Transform;
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var inputComponent = ref entity.GetComponent<InputComponent>();

            Vector2 inputPosition = inputComponent.DragInput;
            bool isPlayerTouch = inputComponent.IsPlayerTouch;


            if (isPlayerTouch)
            {
                Vector3 touchPosition = _camera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y,
                    _camera.nearClipPlane + 2.5f));
                _weaponTransform.position = new Vector3(touchPosition.x, touchPosition.y, touchPosition.z);
            }
        }
    }
}