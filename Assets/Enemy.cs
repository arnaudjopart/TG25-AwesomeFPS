using System;
using PrimeTween;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _currentHealth;
    [SerializeField] private int _maxHealth =10;
    public Action<int> OnTakeDamageEvent;
    [SerializeField] private Vector3 _shakeForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Take Damage")]
    private void TestTakeDamage()
    {
        TakeDamage(1);
    }

    public void TakeDamage(int i)
    {
        _currentHealth -= i;
        OnTakeDamageEvent?.Invoke(_currentHealth);
        Tween.ShakeLocalPosition(transform, _shakeForce, .2f);
    }
}
