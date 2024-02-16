using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int initialPoolSize = 10;

    private List<GameObject> pooledProjectiles;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        pooledProjectiles = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewProjectile();
        }
    }

    void CreateNewProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.SetActive(false);
        pooledProjectiles.Add(projectile);
    }

    public GameObject GetPooledProjectile()
    {
        foreach (GameObject projectile in pooledProjectiles)
        {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
        }

        // If no inactive projectile is found, create a new one and add it to the pool
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.SetActive(false);
        pooledProjectiles.Add(newProjectile);
        return newProjectile;
    }
}
