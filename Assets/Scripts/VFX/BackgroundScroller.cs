using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundSize;
    [SerializeField] float viewZone = 10;
    [SerializeField] float scrollSpeed = 5f;

    private Transform cameraTransform;
    private Transform[] tiles;
    private int leftIndex, rightIndex;
    private float oldCameraPos;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        oldCameraPos = cameraTransform.position.x;

        tiles = new Transform[transform.childCount];
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = tiles.Length - 1;
    }
    void Update()
    {
        float deltaX = oldCameraPos - cameraTransform.position.x;
        Vector3 movementVector = Vector3.right * deltaX / scrollSpeed;

        transform.Translate(movementVector);
        oldCameraPos = cameraTransform.position.x;

        if (oldCameraPos < tiles[leftIndex].position.x + viewZone) ScrollLeft();
        if (oldCameraPos > tiles[rightIndex].position.x - viewZone) ScrollRight();
    }

    #region my method

    void ScrollLeft()
    {
        tiles[rightIndex].position = Vector3.right * (tiles[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
        {
            rightIndex = tiles.Length - 1;
        }
    }
    void ScrollRight()
    {
        tiles[leftIndex].position = Vector3.right * (tiles[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex > tiles.Length - 1)
        {
            leftIndex = 0;
        }
    }

    #endregion

}
