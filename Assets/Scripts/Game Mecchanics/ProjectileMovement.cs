using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void FixedUpdate()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        // Sposta il proiettile verso l'alto
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // Disattiva il proiettile quando diventa invisibile per risparmiare risorse
        gameObject.SetActive(false);
    }
}
