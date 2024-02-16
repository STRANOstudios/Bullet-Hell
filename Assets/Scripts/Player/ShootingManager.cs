using System.Linq;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
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
                Debug.LogError("Layout non gestito");
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
