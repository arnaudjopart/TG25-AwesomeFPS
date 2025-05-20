using UnityEngine;
using UnityEngine.InputSystem;

public class XbotController : MonoBehaviour
{
    private static readonly int JumpTrigger = Animator.StringToHash("JumpTrigger");
    [SerializeField, Range(0,1)]
    private float _moveValue;

    Animator _animator;
    private bool _isShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _animator.SetTrigger(JumpTrigger);
        }

        if (_isShooting) ShootProjectile();
        _animator.SetFloat("Blend", _moveValue);
    }

    private void ShootProjectile()
    {
        throw new System.NotImplementedException();
    }

    public void SayHello(string data)
    {
        Debug.Log(data);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed) _isShooting = true;
        if(context.canceled) _isShooting = false;
    }

    public void FootStepSound(int i)
    {
        if (i == 0) Debug.Log("FootStepSound - Left");
        else Debug.Log("FootStepSound - Right");
    }

}
