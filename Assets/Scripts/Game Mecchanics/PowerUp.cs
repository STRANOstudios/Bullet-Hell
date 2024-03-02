using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public delegate void CollisionAction();
    public static event CollisionAction OnCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollision?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
