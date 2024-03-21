using System;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine.AI;

public class CharacterMovement : NetworkBehaviour
{    
    #region Charactervalue

    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _sprintMultiplier = 0.5f;

    private InputManager _inputManager;
    
    #endregion
    
    public float SprintValue { get; private set; }

    private void Awake() {
        _inputManager = InputManager.instance;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        _characterController.enabled = base.IsOwner;
        this.enabled = base.IsOwner;
    }

    private Vector3 _currentMovement;
    [SerializeField] private CharacterController _characterController;

    private void Update() {
        if(IsOwner == false){
            return;
        }

        HandleMovement();
    }

    private void HandleMovement() {
        
        float speed = _walkSpeed * (SprintValue > 0 ? _sprintMultiplier : 1f); 
        var timeDelta = Time.deltaTime;
        
        
        Vector3 inputDirection = new Vector3(_inputManager.MoveInput.x, 0f, _inputManager.MoveInput.y); 
        Vector3 worldDirection = transform.TransformDirection(inputDirection);

        worldDirection.Normalize();
        
        _currentMovement.x = worldDirection.x * speed * timeDelta;
        _currentMovement.z = worldDirection.z * speed * timeDelta; 
            
        MovementServer(_currentMovement);

        Debug.Log(_currentMovement);
    }

    [ServerRpc]
    private void MovementServer(Vector3 move){
        MovementObserver(move);
    }

    [ObserversRpc]
    private void MovementObserver(Vector3 move){
        _characterController.Move(move);
    }
}
