using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float arcHeight = 1f; // The height of the arc
    public float moveSpeed = 1f; // Speed of the movement
    public float rotationSpeed = 1f; // Speed of the sphere's rotation (optional)

    private Vector3 targetPosition; // The world position towards which the sphere will move

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Input.mousePosition;
        
        mousePos.z = Camera.main.transform.position.y; // Set the Z position to the camera's Y to keep the depth consistent
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        // Get the direction from the player to the mouse
        Vector3 directionToMouse = worldMousePos - player.position;

        // We only care about the X and Z axes, so set Y to 0 to project the direction onto the XZ plane
        directionToMouse.z = 0;

        // Normalize the direction and calculate the target position at a distance in the direction of the mouse
        targetPosition = player.position + directionToMouse.normalized * 5f; // You can adjust the distance (5f) as needed

        // Add arc height by adjusting the target Y position based on a sine function
        float height = Mathf.Sin(mousePos.x/mousePos.y) * arcHeight;
        targetPosition.y += height;

        // Smoothly move the sphere towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        

        // Optional: Rotate the sphere to face the target
        //Vector3 lookDir = targetPosition - transform.position;
        //if (lookDir != Vector3.zero)
        //{
           // Quaternion targetRotation = Quaternion.LookRotation(lookDir);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //}
    }
}
