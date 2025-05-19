using System;
using PrimeTween;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private CharacterController _characterController;

    private Vector3 _moveDirection;
    private Vector2 _inputValue;
    [SerializeField] private float _moveSpeed = 2f;
    private bool groundedPlayer;
    private Vector2 playerVelocity;
    private float jumpHeight =2f;
    [SerializeField] private float gravityValue =9.1f;
    private bool _isJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _camera = Camera.main;
        _characterController = GetComponent<CharacterController>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        var gameplayMap = GetComponent<PlayerInput>().actions.FindActionMap("Player");  
        Debug.Log(gameplayMap.name);
        
        gameplayMap.Disable();
        var uiMap = GetComponent<PlayerInput>().actions.FindActionMap("UI");  
        uiMap.Enable();
        Debug.Log(uiMap.name);
    }

    // Update is called once per frame
    void Update()
    {
        var direction = _camera.transform.forward;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
        
        //var moveVector = _inputValue.x*transform.right+_inputValue.y*transform.forward;
        var moveVector = transform.TransformDirection(new Vector3(_inputValue.x, 0, _inputValue.y));
        //_characterController.SimpleMove(moveVector*_moveSpeed);
        
        groundedPlayer = _characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = moveVector;
        move = Vector3.ClampMagnitude(move, 1f); // Optional: prevents faster diagonal movement


        // Jump
        if (_isJumping && groundedPlayer)
        {
            _isJumping = false;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * _moveSpeed) + (playerVelocity.y * Vector3.up);
        _characterController.Move(finalMove * Time.deltaTime);
        
    }


    public void OnMove(InputAction.CallbackContext ctx)
    {
        _inputValue = ctx.ReadValue<Vector2>();
        
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        GetComponent<CinemachineImpulseSource>().GenerateImpulse();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)_isJumping = true;
    }
}
