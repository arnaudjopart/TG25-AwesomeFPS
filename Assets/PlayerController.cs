using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private CharacterController _characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _camera = Camera.main;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = _camera.transform.forward;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
       
        _characterController.SimpleMove(Vector3.zero);
        transform.rotation = lookRotation;
    }
}
