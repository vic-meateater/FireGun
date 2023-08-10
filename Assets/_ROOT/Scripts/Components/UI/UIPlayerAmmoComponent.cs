using Scellecs.Morpeh;
using TMPro;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct UIPlayerAmmoComponent : IComponent
{
    public TextMeshProUGUI UIPlayerCurrentAmmoCount;
    public TextMeshProUGUI UIPlayerTotalAmmoCount;
}