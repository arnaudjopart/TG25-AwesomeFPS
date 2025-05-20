using UnityEngine;
using UnityEngine.InputSystem;

public class XbotController : MonoBehaviour
{
    private static readonly int JumpTrigger = Animator.StringToHash("JumpTrigger");

    Animator _animator;
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
    }
}
