using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UIAmmoCountLateSystem))]
public sealed class UIAmmoCountLateSystem : LateUpdateSystem
{
    public GlobalVariableInt GlobalPlayerCurrentAmmoCount;
    public GlobalVariableInt GlobalPlayerTotalAmmoCount;
    private UIPlayerAmmoComponent _ui;
    
    public override void OnAwake()
    {
        _ui = World.Filter.With<UIPlayerAmmoComponent>().FirstOrDefault().GetComponent<UIPlayerAmmoComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        _ui.UIPlayerCurrentAmmoCount.text = GlobalPlayerCurrentAmmoCount.Value.ToString();
        _ui.UIPlayerTotalAmmoCount.text = GlobalPlayerTotalAmmoCount.Value.ToString();
    }
}