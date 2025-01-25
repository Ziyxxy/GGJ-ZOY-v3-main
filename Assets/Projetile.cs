using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1; // Damage dealt by the projectile

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the projectile collides with a target
        if (collider.gameObject.CompareTag("Target"))
        {
            Destroy(collider.gameObject); // Destroy the target object
            Destroy(gameObject); // Destroy the projectile
        }

        if (collider.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy the projectile on hitting a wall
        }

        if (collider.gameObject.CompareTag("Boss"))
        {
            BossHealth bossHealth = collider.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage); // Call TakeDamage on the boss
            }
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
