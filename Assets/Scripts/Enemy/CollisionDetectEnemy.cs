using UnityEngine;

public class CollisionDetectEnemy : MonoBehaviour
{
    public delegate void CollisionAction();
    public static event CollisionAction OnCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            OnCollision?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
