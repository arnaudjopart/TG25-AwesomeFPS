using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text _liveText;
    
    private void OnEnable()
    {
        player.OnPlayerDeathEvent += ReactToPlayerDeath;
        int currentLives = player.SubscribeToPlayerLivesChange(UpdateLiveText);
        UpdateLiveText(currentLives);
    }

    private void OnDisable()
    {
        player.OnPlayerDeathEvent -= ReactToPlayerDeath;
        player.UnsubscribeToPlayerLivesChange(UpdateLiveText);
    }

    private void UpdateLiveText(int value)
    {
        _liveText.SetText("Player Lives: " + value);
    }

    private void OnDestroy()
    {
        
    }

    private void Update()
    {
        
    }

    public void ReactToPlayerDeath()
    {
        Debug.Log("Get Gud");
    }

    public void OnPlayerAttack()
    {
        Debug.Log("On Player Attack");
    }
}