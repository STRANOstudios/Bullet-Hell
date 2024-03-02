using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public delegate void CollisionAction();
    public static event CollisionAction OnCollision;

    private void OnParticleCollision(GameObject other)
    {

        OnCollision?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp")) return;

        OnCollision?.Invoke();
    }
}
