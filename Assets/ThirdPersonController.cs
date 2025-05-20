using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    private Vector2 _moveInput;
    private Camera _camera;
    [SerializeField] private float _rotationSpeed = 250;
    private Animator _animator;
    private CharacterController _characterController;
    [SerializeField] private bool _isGrounded;
    private float playerVelocityY;
    private bool _applyJump;
    private float gravityValue = -9.81f;
    private float jumpHeight=3;
    private bool _isAlreadyJumping;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _characterController.isGrounded;
        _animator.SetBool("IsGrounded", _isGrounded);
        if (_moveInput.magnitude > 0.1f)
        {
            var forwardDirection = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up);
            var rightDirection = _camera.transform.right;
            var moveDirection = forwardDirection * _moveInput.y+rightDirection * _moveInput.x;
            var rotation = Quaternion.LookRotation(moveDirection.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
            
        }
        if (_isGrounded && playerVelocityY < 0)
        {
            playerVelocityY=  0f;
        }


        if (_applyJump)
        {
            _applyJump = false;
            // Jump
            if (_isGrounded)
            {
                _isAlreadyJumping = true;
                _animator.SetTrigger("JumpTrigger");
                playerVelocityY = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }
        }
        
        
        playerVelocityY+= gravityValue * Time.deltaTime;
        var moveMagnitude = _moveInput.magnitude;
        _animator.SetFloat("Blend", moveMagnitude);
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnAnimatorMove()
    {
        var velocity = _animator.deltaPosition;
        if(_isGrounded) velocity.y = playerVelocityY*Time.deltaTime;
        
        
        //velocity.y = playerVelocityY*Time.deltaTime;
        Debug.Log(velocity);
        _characterController.Move(velocity);
        _isAlreadyJumping = _characterController.isGrounded; // sync with animator
    }

    public void FootStepSound(int value)
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.collider.name);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        if (_isAlreadyJumping) return;
        _applyJump = true;
    }
}
