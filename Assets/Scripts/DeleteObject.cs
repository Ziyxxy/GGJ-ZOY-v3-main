using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    // This function will be triggered when the projectile enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the projectile collides with an object that has the tag "DeathBarrier"
        if (collider.gameObject.CompareTag("DeathBarrier"))
        {
           
            Destroy(GameObject.Find("Cannon Horizontal"));
            Destroy(GameObject.Find("Level (2)"));

            
        }
    }
}
