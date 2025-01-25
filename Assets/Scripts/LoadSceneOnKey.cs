using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class LoadSceneOnKey : MonoBehaviour
{
    public string sceneName; // Name of the scene to load
    public Vector3 requiredPosition; // The position to check
    public float positionThreshold = 0.1f; // Tolerance for position checking

    void Update()
    {
        // Check if the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            

            // Check if the current position is close to the required position
            if (Vector3.Distance(transform.position, requiredPosition) <= positionThreshold)
            {
                // Load the scene
                

                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
