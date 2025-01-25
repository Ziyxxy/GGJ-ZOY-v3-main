using Platformer.Mechanics;
using UnityEngine;

public class Projetile : MonoBehaviour
{
    // This function will be triggered when the projectile enters a trigger collider
    public int BossHealth = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the projectile collides with an object that has the tag "Target"
        if (collider.gameObject.CompareTag("Target"))
        {
            // Destroy the target object
            Destroy(collider.gameObject);

            // Optionally, destroy the projectile as well
            Destroy(gameObject);
        }

        if (collider.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        }

        if (collider.gameObject.CompareTag("Boss")){
            BossHealth -= 1;
            if (BossHealth <= 0){
                Destroy(GameObject.Find("Boss"));
            }
        }
        
    }

}
