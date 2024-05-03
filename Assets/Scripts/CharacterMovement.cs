using System;
using UnityEngine;
 using Mirror;

public class CharacterMovement : NetworkBehaviour
{    
    #region Charactervalue

    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _sprintMultiplier = 0.5f;

    private InputManager _inputManager;
    
    #endregion
    
    public float SprintValue { get; private set; }
    [SerializeField] private float rotationSpeed;

    private void Awake() {
        _inputManager = InputManager.instance;
    }

    private Vector3 _currentMovement;
    [SerializeField] private CharacterController _characterController;

    private void Update() {

        HandleMovement();
    }

    [Client]
    private void HandleMovement() {
        if(!isOwned) return;

        float speed = _walkSpeed * (SprintValue > 0 ? _sprintMultiplier : 1f); 
        var timeDelta = Time.deltaTime;

        Vector3 inputDirection = new Vector3(_inputManager.MoveInput.x, 0f, _inputManager.MoveInput.y); 

        inputDirection.Normalize();

        _currentMovement = inputDirection * (speed * timeDelta);

        MovementServer(_currentMovement);

        // Rotate the character if there's movement
        if (_currentMovement.magnitude > 0) {
            Quaternion targetRotation = Quaternion.LookRotation(_currentMovement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
    

    [Command]
    private void MovementServer(Vector3 move){
        MovementObserver(move);
    }

    [ClientRpc]
    private void MovementObserver(Vector3 move){
        _characterController.Move(move);
    }
}
