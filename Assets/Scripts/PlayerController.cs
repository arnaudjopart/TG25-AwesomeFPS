using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private CharacterController _characterController;

    private Vector3 _moveDirection;
    private Vector2 _inputValue;
    [SerializeField] private float _moveSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _camera = Camera.main;
        _characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
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
        _characterController.SimpleMove(moveVector*_moveSpeed);
        
    }


    public void OnMove(InputAction.CallbackContext ctx)
    {
        _inputValue = ctx.ReadValue<Vector2>();
        
    }
}
