using UnityEngine;
using System.Collections.Generic;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    private Shooter shooter;

    void Start()
    {
        shooter = GetComponent<Shooter>();

        if (spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points assigned to ProjectileSpawner!");
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootFromRandomSpawnPoint();
        }
    }

    void ShootFromRandomSpawnPoint()
    {
        // Seleziona casualmente un punto di spawn dalla lista
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Imposta la posizione del proiettile sul punto di spawn selezionato e spara
        shooter.ShootFromPosition(spawnPoint.position);
    }
}
