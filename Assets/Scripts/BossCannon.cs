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
        timer+=Time.deltaTime;
        
        if (timer > frequency){
            timer = 0f;
            Shoot();
        } 
        
    }

    void Shoot()
    {
        Vector2 playerPosition = playerTransform.position;
        Vector2 shootPoint = transform.position;
        shootPoint.x -= 0.8f;

        // Calculate the direction from the player to the mouse position
        Vector2 direction = new (-1f, 0f);
        Debug.Log(playerPosition);
        // Instantiate the projectile at the shoot point
        if (playerPosition.y > -0.75f && playerPosition.y < 0.25f){
            shootPoint.y -= 1.35f;
        }
        if (playerPosition.y > 2f){
            shootPoint.y += 1.424f;   
        } 
        
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
