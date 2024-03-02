using UnityEngine;

public class IA1 : MonoBehaviour
{
    [SerializeField] Transform[] bulletSpawnPoints;
    [SerializeField] bool rotateOnZ = true;

    [SerializeField, Range(0, 2)] int ShootType;

    private void Start()
    {
        foreach (Transform t in bulletSpawnPoints)
        {
            t.gameObject.SetActive(false);
        }
        switch (ShootType)
        {
            case 0:
                ShootTwoAtATime();
                break;
            case 1:
                ShootAllAtOnce();
                break;
            case 2:
                ShootRandomly();
                break;
            default:
                break;
        }
    }

    void Update()
    {
        RotateOnZ();
    }

    void RotateOnZ()
    {
        if (rotateOnZ) transform.Rotate(50f * Time.deltaTime * Vector3.forward);
    }

    void ShootTwoAtATime()
    {
        bulletSpawnPoints[0].gameObject.SetActive(true);
        bulletSpawnPoints[2].gameObject.SetActive(true);
    }

    void ShootAllAtOnce()
    {
        foreach (Transform t in bulletSpawnPoints)
        {
            t.gameObject.SetActive(true);
        }
    }

    void ShootRandomly()
    {
        int tmp = Random.Range(0, bulletSpawnPoints.Length);
        bulletSpawnPoints[tmp].gameObject.SetActive(true);
    }
}
