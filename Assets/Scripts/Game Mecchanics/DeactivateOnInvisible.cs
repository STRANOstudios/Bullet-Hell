using BulletHell.Spawners;
using UnityEngine;

public class DeactivateOnInvisible : MonoBehaviour
{
    void FixedUpdate()
    {
        // Deactivate the object if it is not visible from the main camera
        if (!IsVisibleByMainCamera())
        {
            BulletController bulletController = gameObject.GetComponent<BulletController>();
            if (bulletController != null) bulletController.ResetGameObject();
            gameObject.SetActive(false);
        }
    }

    bool IsVisibleByMainCamera()
    {
        // Check if the object is visible from the main camera using a viewport check
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
