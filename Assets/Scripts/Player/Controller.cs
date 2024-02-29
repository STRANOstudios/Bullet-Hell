using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Collider2D referenceCollider;

    private float minX, maxX;
    private float minY, maxY;

    void Start()
    {
        if (referenceCollider == null)
        {
            Debug.LogError("Reference Collider is not assigned in the Inspector!");
        }

        // Get the size of the reference collider
        float referenceColliderWidth = referenceCollider.bounds.size.x;
        float referenceColliderHeight = referenceCollider.bounds.size.y;

        // Calculate the limits based on the collider size
        minX = (-referenceColliderWidth / 2f) + referenceCollider.offset.x;
        maxX = (referenceColliderWidth / 2f) + referenceCollider.offset.x;
        minY = (-referenceColliderHeight / 2f) + referenceCollider.offset.y;
        maxY = (referenceColliderHeight / 2f) + referenceCollider.offset.y;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        // Limit the position of the spaceship within the screen
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
