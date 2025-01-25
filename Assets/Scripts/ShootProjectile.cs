using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float projectileSpeed = 10f; // Speed of the projectile
    public Transform shootPoint; // The point from which the projectile will be shot (e.g., player's position or a separate muzzle)

    void Update()
    {
        // Check for mouse click (left mouse button)
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure that the projectile moves in the 2D plane (Z axis should be 0)

        // Calculate the direction from the player to the mouse position
        Vector3 direction = (mousePos - shootPoint.position).normalized;

        // Instantiate the projectile at the shoot point
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the projectile (assuming the projectile has a Rigidbody2D)
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        

        if (rb != null)
        {
            // Apply a velocity to the projectile to make it move toward the mouse position
            rb.linearVelocity = direction * projectileSpeed;
        }
        Destroy(projectile, 2.5f);
    }
}
