using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;

    private float nextFireTime;

    void Update()
    {
        // Logica di sparo rimossa dal FixedUpdate e spostata in Update

        // Potresti voler mantenere la vecchia logica FixedUpdate per il movimento se necessario
    }

    public void ShootFromPosition(Vector3 spawnPosition)
    {
        // Imposta il tempo per il prossimo possibile sparo
        nextFireTime = Time.time + fireRate;

        // Ottieni un proiettile dal pool
        GameObject projectile = ObjectPooler.Instance.GetPooledProjectile();

        if (projectile != null)
        {
            // Posiziona il proiettile sulla posizione specificata e attivalo
            projectile.transform.position = spawnPosition;
            projectile.SetActive(true);
        }
    }
}
