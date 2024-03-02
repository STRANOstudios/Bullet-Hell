using UnityEngine;

public class EnemyLayer : MonoBehaviour
{
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }
}
