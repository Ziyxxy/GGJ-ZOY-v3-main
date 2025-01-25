using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 30;
    public float currentHealth;
    public GameObject healthBarPrefab; // Reference to the health bar prefab

    private GameObject healthBar;
    private Image healthBarForeground;
    private Vector3 healthBarOffset = new Vector3(0, 2, 0); // Adjust Y value to raise the health bar

    void Start()
    {
        currentHealth = maxHealth;

        // Create health bar above the enemy
        healthBar = Instantiate(healthBarPrefab, transform.position + healthBarOffset, Quaternion.identity, transform);
        healthBarForeground = healthBar.transform.Find("Foreground").GetComponent<Image>();
    }

    void Update()
    {
        // Update health bar position above enemy
        healthBar.transform.position = transform.position + healthBarOffset;

        // Update health bar fill amount based on current health
        if (healthBarForeground != null)
        {
            float healthPercentage = currentHealth / maxHealth;
            healthBarForeground.fillAmount = healthPercentage;
        }
    }

    // Example method to damage the enemy
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Handle enemy death
        }
    }
}
