using System.Linq;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private float fireRate = 0.5f;

    [SerializeField, Range(1, 3)] int layoutNumber = 1;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            ShootProjectile();
        }
    }

    private void OnEnable()
    {
        // Subscribe to the pause event
        PowerUp.OnCollision += LayoutNumberIncrement;
    }

    private void OnDisable()
    {
        // Unsubscribe from the pause event
        PowerUp.OnCollision -= LayoutNumberIncrement;
    }

    public void LayoutNumberIncrement() { if (layoutNumber < 3) layoutNumber++; }

    void ShootProjectile()
    {
        nextFireTime = Time.time + fireRate;

        switch (layoutNumber)
        {
            case 1:
                LayoutCentralPosition();
                break;
            case 2:
                LayoutWingsPosition();
                break;
            case 3:
                LayoutAllPosition();
                break;
            default:
                break;
        }
    }

    void LayoutAllPosition()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject projectile = ObjectPooler.Instance.GetPooledProjectile();
            if (projectile != null)
            {
                projectile.transform.position = firePoint.position;
                projectile.SetActive(true);
            }
        }
    }

    void LayoutCentralPosition()
    {

        GameObject projectile = ObjectPooler.Instance.GetPooledProjectile();

        if (projectile != null)
        {
            projectile.transform.position = firePoints[2].position;

            projectile.SetActive(true);
        }
    }

    void LayoutWingsPosition()
    {
        for (int i = 0; i < firePoints.Count() - 1; i++)
        {
            GameObject projectile = ObjectPooler.Instance.GetPooledProjectile();
            if (projectile != null)
            {
                projectile.transform.position = firePoints[i].position;
                projectile.SetActive(true);
            }
        }
    }
}
