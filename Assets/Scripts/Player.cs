using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnPlayerDeathEvent;
    private Action<int> _onPlayerLivesChangeEvent;
    private void Awake()
    {
        _currentLives.value = _playerData.m_maxLives;
    }
    void Start()
    {
        _onPlayerLivesChangeEvent?.Invoke(_currentLives.value);
    }
    public int SubscribeToPlayerLivesChange(Action<int> action)
    {
        _onPlayerLivesChangeEvent += action;
        return _currentLives.value;
    }
    public void UnsubscribeToPlayerLivesChange(Action<int> action)
    {
        _onPlayerLivesChangeEvent -= action;
    }
    
    [ContextMenu("Tell Me your Max Lives")]
    public void GetMaxLives()
    {
        Debug.Log("Player's max lives: "+_playerData.m_maxLives);
    }
    [ContextMenu("Game Over")]
    public void GameOver()
    {
        Debug.Log("Player's Dead");
        if(OnPlayerDeathEvent!=null) OnPlayerDeathEvent.Invoke();
        
    }
    [ContextMenu("Take Damage")]
    public void TakeDamage()
    {
        Debug.Log("Player is getting their ass kicked");
        _currentLives.value--;
        _onPlayerLivesChangeEvent?.Invoke(_currentLives.value);
    }
    [ContextMenu("Attack Target")]
    public void Attack()
    {
        Debug.Log("Attack With "+_currentWeaponData.m_itemName);
        _onAttackEvent?.Raise();
    }
    
    #region Privates & Protected

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WeaponItemData _currentWeaponData;
    [SerializeField] private GameEvent _onAttackEvent;
    [SerializeField] private IntValue _currentLives;
    
    #endregion


}