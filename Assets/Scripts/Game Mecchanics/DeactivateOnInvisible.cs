using UnityEngine;

public class DeactivateOnInvisible : MonoBehaviour
{
    void Update()
    {
        // Deactivate the object if it is not visible from the main camera
        if (!IsVisibleByMainCamera())
        {
            gameObject.SetActive(false);
        }
    }

    bool IsVisibleByMainCamera()
    {
        // Check if the object is visible from the main camera using a viewport check
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
