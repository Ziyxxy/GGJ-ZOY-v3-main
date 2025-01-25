using System.Threading;
using UnityEngine;

public class BossCannon : MonoBehaviour
{
    
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float projectileSpeed = 0.2f; // Speed of the projectile
    private float timer = 0f;
    public Transform playerTransform;
    
    

    [SerializeField] public float frequency = 2f;

    GameObject projectile;
    void Update()
    {
        Vector2 playerPosition = playerTransform.position;
        Vector2 newPosition = transform.position;
        newPosition.y = playerPosition.y;

        transform.position = newPosition;
        
        timer+=Time.deltaTime;
        
        if (timer > frequency){
            timer = 0f;
            Shoot();
        } 
        
    }

    void Shoot()
    {
        
        Vector2 shootPoint = transform.position;
        shootPoint.x -= 0.8f;

        // Calculate the direction from the player to the mouse position
        Vector2 direction = new (-1f, 0f);
        // Instantiate the projectile at the shoot point
        projectile = Instantiate(projectilePrefab, shootPoint, Quaternion.identity);

        shootPoint = transform.position;
        // Get the Rigidbody2D component of the projectile (assuming the projectile has a Rigidbody2D)
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        Destroy(projectile, 7f);

        if (rb != null)
        {
            // Apply a velocity to the projectile to make it move toward the mouse position
            rb.linearVelocity = direction * projectileSpeed;
        }
        
    }
}
