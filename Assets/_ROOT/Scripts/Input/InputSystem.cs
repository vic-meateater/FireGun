using _ROOT.Scripts.Helpers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputSystem))]
public sealed class InputSystem : UpdateSystem
{
    private Filter _inputFilter;
    private Filter _playerStateFilter;
    private PlayerInputAsset _playerInput;
    private bool _isPlayerTouchScreen = false;

    public override void OnAwake()
    {
        _inputFilter = World.Filter.With<InputComponent>().With<PlayerStatesComponent>();
        _playerInput = new PlayerInputAsset();
        _playerInput.Enable();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var e in _inputFilter)
        {
            ref var input = ref e.GetComponent<InputComponent>();
            ref var playerState = ref e.GetComponent<PlayerStatesComponent>();

            input.DragInput = _playerInput.PlayerInput.Move.ReadValue<Vector2>();
            input.IsPlayerTouchScreen = _playerInput.PlayerInput.Touch.ReadValue<float>() > 0;

            //_isPlayerMouseMoving = input.DragInput == Vector2.zero;
            _isPlayerTouchScreen = input.IsPlayerTouchScreen;

            playerState.CurrentState = _isPlayerTouchScreen
                ? PlayerStates.AutoShooting
                : PlayerStates.Idle;
        }
    }
}