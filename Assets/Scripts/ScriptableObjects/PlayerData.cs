using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Gameplay/Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public float m_moveSpeed = 5f;
    public float m_jumpForce = 3f;
    public int m_maxLives = 3;
}