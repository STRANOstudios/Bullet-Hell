using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Collider2D referenceCollider;

    void Start()
    {
        if (referenceCollider == null)
        {
            Debug.LogError("Reference Collider is not assigned in the Inspector!");
        }
    }

    void FixedUpdate()
    {
        if (referenceCollider == null)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        // Get the size of the reference collider
        float referenceColliderWidth = referenceCollider.bounds.size.x;
        float referenceColliderHeight = referenceCollider.bounds.size.y;

        // Calculate the limits based on the collider size
        float minX = (-referenceColliderWidth / 2f) + referenceCollider.offset.x;
        float maxX = (referenceColliderWidth / 2f) + referenceCollider.offset.x;
        float minY = (-referenceColliderHeight / 2f) + referenceCollider.offset.y;
        float maxY = (referenceColliderHeight / 2f) + referenceCollider.offset.y;

        // Limit the position of the spaceship within the screen
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
