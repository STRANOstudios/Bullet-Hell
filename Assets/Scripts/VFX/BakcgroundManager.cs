using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] float backgroundSize;
    [SerializeField] float constanSpeed;

    [SerializeField] private Collider2D BoundsCollider2D;

    private float constanSpeedBackup;
    private Transform[] tiles;
    private Transform[][] tiles2;
    private int[][] leftIndex, rightIndex;

    private float minX, maxX;

    void Start()
    {
        if (BoundsCollider2D == null)
        {
            Debug.LogError("Reference Collider is not assigned in the Inspector!");
        }

        constanSpeedBackup = constanSpeed;

        int tmp = transform.childCount;
        tiles = new Transform[tmp];
        tiles2 = new Transform[tmp][];
        leftIndex = new int[tmp][];
        rightIndex = new int[tmp][];

        for (int i = 0; i < tiles2.Length; i++)
        {
            tiles[i] = transform.GetChild(i);

            int tp = transform.GetChild(i).childCount;
            tiles2[i] = new Transform[tp];
            leftIndex[i] = new int[tp];
            rightIndex[i] = new int[tp];

            for (int j = 0; j < tiles2[i].Length; j++)
            {
                tiles2[i][j] = transform.GetChild(i).GetChild(j);
                leftIndex[i][j] = 0;
                rightIndex[i][j] = tiles2[i].Length - 1;
            }
        }

        // Get the size of the reference collider
        float referenceColliderWidth = BoundsCollider2D.bounds.size.x;

        // Calculate the limits based on the collider size
        minX = (-referenceColliderWidth / 2f) + BoundsCollider2D.offset.x;
        maxX = (referenceColliderWidth / 2f) + BoundsCollider2D.offset.x;
    }

    void FixedUpdate()
    {
        Vector3 movementVector = Vector3.left * constanSpeed;
        Movement(movementVector);
    }

    #region my method

    void Movement(Vector3 movementVector)
    {
        for (int i = 0; i < tiles2.Length; i++)
        {
            for (int j = 0; j < tiles2[i].Length; j++)
            {
                tiles2[i][j].Translate((movementVector * (i + 1)));
                if (tiles2[i][j].position.x > maxX) ScrollLeft(i, j);
                if (tiles2[i][j].position.x < minX) ScrollRight(i, j);
            }
        }
    }

    void ScrollLeft(int i, int j)
    {
        tiles2[i][j].position -= Vector3.left * (tiles2[i][j].position.x - backgroundSize);
    }

    void ScrollRight(int i, int j)
    {
        tiles2[i][j].position += Vector3.left * (tiles2[i][j].position.x - backgroundSize);
    }

    #endregion

    public void ConstanSpeed(float value) => constanSpeed = value;

    public void ResetSpeed() => constanSpeed = constanSpeedBackup;

}
