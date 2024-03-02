using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public delegate void GameOver();
    public static event GameOver gameover;

    [SerializeField] GameObject player;

    [SerializeField, Range(0, 30)] int hp = 30;

    private int score = 1;

    private int hpMax = 30;

    private void Awake()
    {
        #region Singleton

        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);

        #endregion
    }

    private void OnEnable()
    {
        CollisionDetect.OnCollision += HPDecrement;
        Med.OnCollision += HPReset;
        CollisionDetectEnemy.OnCollision += ScoreIncrement;
    }

    private void OnDisable()
    {
        CollisionDetect.OnCollision -= HPDecrement;
        Med.OnCollision -= HPReset;
        CollisionDetectEnemy.OnCollision -= ScoreIncrement;
    }

    GameObject Player => player;

    public void HPDecrement()
    {
        hp--;
        if (hp < 1) gameover?.Invoke();
    }

    public void HPReset()
    {
        hp = hpMax;
    }

    public void ScoreIncrement()
    {
        score++;
    }

    public int Score => score;
}
