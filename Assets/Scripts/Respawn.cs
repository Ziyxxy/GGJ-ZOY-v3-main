using UnityEngine;

public class Respawn : MonoBehaviour
{
    // This function will be triggered when the projectile enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the projectile collides with an object that has the tag "DeathBarrier"
        if (collider.gameObject.CompareTag("DeathBarrier"))
        {
           
            GameObject.Find("Player").transform.position = new (0f, -0.59f, 1f);

            
        }
    }
}
