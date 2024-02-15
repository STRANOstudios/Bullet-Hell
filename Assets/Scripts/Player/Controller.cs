using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;

    void FixedUpdate()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f) * horizontalSpeed * Time.fixedDeltaTime;
        transform.Translate(horizontalMovement);

        // Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 verticalMovement = new Vector3(0f, verticalInput, 0f) * verticalSpeed * Time.fixedDeltaTime;
        transform.Translate(verticalMovement);

        // Limit the position of the spaceship within the screen
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
