using System.Threading;
using UnityEngine;

public class CannonShootHorizontal : MonoBehaviour
{
    
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float projectileSpeed = 0.4f; // Speed of the projectile
    public Transform shootPoint; // The point from which the projectile will be shot (e.g., player's position or a separate muzzle)
    private float timer = 0f;
    

    [SerializeField] public float frequency = 1f;

    GameObject projectile;
    void Update()
    {
        timer+=Time.deltaTime;
        
        if (timer > frequency){
            timer = 0f;
            Shoot();
        } 
        
    }

    void Shoot()
    {
        Vector3 shootPoint = transform.position;
        shootPoint.x -= 0.8f;

        // Calculate the direction from the player to the mouse position
        Vector3 direction = new (-1f, 0f, 0f);

        // Instantiate the projectile at the shoot point
        
        projectile = Instantiate(projectilePrefab, shootPoint, Quaternion.identity);

        shootPoint = transform.position;
        // Get the Rigidbody2D component of the projectile (assuming the projectile has a Rigidbody2D)
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        Destroy(projectile, 0.5f);

        if (rb != null)
        {
            // Apply a velocity to the projectile to make it move toward the mouse position
            rb.linearVelocity = direction * projectileSpeed;
        }
        
    }
}
