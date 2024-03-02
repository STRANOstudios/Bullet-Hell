using UnityEngine;
using static GameManager;

public class Pause : MonoBehaviour
{
    public delegate void PauseValue(bool value);
    public static event PauseValue IsPaused = null;

    bool isPaused = false;
    bool isGameover = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameover)
        {
            isPaused = !isPaused;
            HandlePause();
        }
    }

    private void OnEnable()
    {
        GameManager.gameover += gameover;
    }

    private void OnDisable()
    {
        GameManager.gameover -= gameover;
    }

    void HandlePause()
    {
        IsPaused?.Invoke(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void gameover()
    {
        isGameover = true;
        Time.timeScale = 0f;
    }
}
