using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static InputManager instance;
    
    [SerializeField] private InputActionAsset _playerControls;
    
    [Header("Input Action Map Name")] 
    [SerializeField] private string _actionMapName = "PlayerControls";

    [Header("Input Actions")] 
    [SerializeField] private string _move = "Move";
    [SerializeField] private string _look = "Look";

    private InputAction _moveAction;
    private InputAction _lookAction;
    
    public Vector2 MoveInput { get;  set; }
    public Vector2 LookInput { get;  set; }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        if(_playerControls == null){
            Debug.Log("NO PLAYER CONTROLS");
            return;
        }

        if(_playerControls.FindActionMap(_actionMapName) == null){
            Debug.Log("No Map");
            return;
        }

        if(_playerControls.FindActionMap(_actionMapName).FindAction(_move) == null || 
        _playerControls.FindActionMap(_actionMapName).FindAction(_move) == null){
            Debug.Log("No Actions");
            return;
        }
        
        _moveAction = _playerControls.FindActionMap(_actionMapName).FindAction(_move);
        _lookAction = _playerControls.FindActionMap(_actionMapName).FindAction(_look);
        
        _moveAction.performed += context =>
        {
            MoveInput = context.ReadValue<Vector2>();
        };
        
        _moveAction.canceled += context =>
        {
            MoveInput = Vector2.zero;
        };
        
        _lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        _lookAction.canceled += context => LookInput = Vector2.zero;
        
        _moveAction.Enable();
        _lookAction.Enable();
    }

    public void OnDisable() {
        _moveAction.Disable();
        _lookAction.Disable();
    }
}
