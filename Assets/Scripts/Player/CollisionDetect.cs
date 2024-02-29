using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null) return;

        Debug.Log("colpito");
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("colpito");
    }
}
