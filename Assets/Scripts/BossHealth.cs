using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHP = 30;

    public void TakeDamage(int damage)
    {
        bossHP -= damage;
        if (bossHP <= 0)
        {
            Destroy(gameObject); // Destroy the boss GameObject when health is zero or less
            Destroy(GameObject.Find("Cannon Horizontal (1)"));
            Destroy(GameObject.Find("Wall"));
        }
    }
}