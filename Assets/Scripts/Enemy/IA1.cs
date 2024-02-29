using UnityEngine;

public class IA1 : MonoBehaviour
{
    public float speed = 3f;
    public BoxCollider2D movementBounds;
    public GameObject bulletPrefab;
    public Transform[] bulletSpawnPoints;
    public Transform playerTransform; // Riferimento al Transform del giocatore
    public float shootingInterval = 2f;
    public float bulletSpeed = 5f;
    public bool rotateOnZ = true;

    private float timeSinceLastShot = 0f;

    void Update()
    {
        MoveWithinBounds();
        RotateOnZ();

        // Scegli il metodo di sparo desiderato
        // ShootTwoAtATime();
        // ShootAllAtOnce();
        // ShootRandomly();
        // ShootNearestToPlayer();
    }

    void MoveWithinBounds()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + new Vector3(horizontalMovement, verticalMovement, 0) * speed * Time.deltaTime;

        if (movementBounds.bounds.Contains(newPosition))
        {
            transform.Translate(new Vector3(horizontalMovement, verticalMovement, 0) * speed * Time.deltaTime);
        }
    }

    void RotateOnZ()
    {
        if (rotateOnZ)
        {
            transform.Rotate(Vector3.forward * 50f * Time.deltaTime);
        }
    }

    void ShootTwoAtATime()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingInterval)
        {
            timeSinceLastShot = 0f;

            foreach (Transform spawnPoint in bulletSpawnPoints)
            {
                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = Vector2.down * bulletSpeed;
            }
        }
    }

    void ShootAllAtOnce()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingInterval)
        {
            timeSinceLastShot = 0f;

            foreach (Transform spawnPoint in bulletSpawnPoints)
            {
                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = Vector2.down * bulletSpeed;
            }
        }
    }

    void ShootRandomly()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingInterval)
        {
            timeSinceLastShot = 0f;

            int randomIndex = Random.Range(0, bulletSpawnPoints.Length);
            Transform spawnPoint = bulletSpawnPoints[randomIndex];

            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.down * bulletSpeed;
        }
    }

    void ShootNearestToPlayer()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingInterval)
        {
            timeSinceLastShot = 0f;

            Transform nearestSpawnPoint = GetNearestSpawnPoint();
            GameObject bullet = Instantiate(bulletPrefab, nearestSpawnPoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.down * bulletSpeed;
        }
    }

    Transform GetNearestSpawnPoint()
    {
        Transform nearestSpawnPoint = null;
        float nearestDistance = float.MaxValue;

        foreach (Transform spawnPoint in bulletSpawnPoints)
        {
            float distanceToPlayer = Vector2.Distance(spawnPoint.position, playerTransform.position);
            if (distanceToPlayer < nearestDistance)
            {
                nearestDistance = distanceToPlayer;
                nearestSpawnPoint = spawnPoint;
            }
        }

        return nearestSpawnPoint;
    }
}
