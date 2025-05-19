using UnityEngine;

public class LookAtTargetWithSpeed : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSpeed =10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        
    }
}
