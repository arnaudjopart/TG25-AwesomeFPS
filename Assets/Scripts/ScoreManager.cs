using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.OnPlayerDeathEvent += SaveCurrentScore;
    }

    private void OnDestroy()
    {
        _player.OnPlayerDeathEvent -= SaveCurrentScore;
    }

    private void SaveCurrentScore()
    {
        Debug.Log("Saving Score");
    }
}