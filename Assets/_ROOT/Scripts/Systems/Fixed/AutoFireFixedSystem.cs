using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using System.Collections.Generic;
using System.Linq;
using _ROOT.Scripts.Helpers;
using Scellecs.Morpeh.Globals.Variables;
using Unity.VisualScripting;


[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AutoFireFixedSystem))]
public sealed class AutoFireFixedSystem : FixedUpdateSystem
{
    private Filter _weaponFilter;
    private PlayerStatesComponent _currenPlayerState;

    private WeaponComponent _weapon;

    public GlobalEventObject OnBulletCollisionReact;
    public GlobalVariableInt GlobalIntCurrentBulletCount;
    public GlobalEvent GENotEnoughAmmo;

    public override void OnAwake()
    {
        Debug.Log("OnAwake AutoFireFixedSystem");
        _weaponFilter = World.Filter.With<WeaponComponent>();
        OnBulletCollisionReact.Subscribe(OnReact);
    }


    public override void OnUpdate(float deltaTime)
    {
        _currenPlayerState = World.Filter.With<PlayerStatesComponent>().FirstOrDefault()
            .GetComponent<PlayerStatesComponent>();
        foreach (var entity in _weaponFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();
            _weapon = weapon;

            var isValidPlayerState = _currenPlayerState.CurrentState == PlayerStates.AutoShooting;

            if (isValidPlayerState && CanShoot(weapon) && IsEnoughBullet())
            {
                var bulletGO = weapon.bulletPool.Get();

                if (bulletGO != null)
                {
                    GlobalIntCurrentBulletCount.Value -= weapon.BulletPerShootCount;
                    bulletGO.transform.position = weapon.BulletSpawnPoint.position;

                    var bulletRigidbody = bulletGO.GetComponentInChildren<Rigidbody>();


                    //TODO: заменить скорость полета пули 19f
                    bulletRigidbody.velocity = weapon.BulletSpawnPoint.forward * 19f;

                    weapon.LastShotTime = Time.time;
                }
            }
            else if (!IsEnoughBullet())
            {
                GENotEnoughAmmo.Publish();
            }
        }
    }

    private bool IsEnoughBullet() => GlobalIntCurrentBulletCount.Value > 0;


    private void OnReact(IEnumerable<UnityEngine.Object> obj) =>
        _weapon.bulletPool.Release(obj.FirstOrDefault().GameObject());


    private bool CanShoot(WeaponComponent weapon) =>
        Time.time - weapon.LastShotTime >= weapon.FireRate;
}