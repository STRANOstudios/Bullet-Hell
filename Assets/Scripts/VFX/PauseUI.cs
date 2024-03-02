using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] CanvasGroup pause;
    [SerializeField] CanvasGroup gameover;

    private void OnEnable()
    {
        // Subscribe to the pause event
        Pause.IsPaused += OnPauseStateChanged;
        GameManager.gameover += OnGameoverStateChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from the pause event
        Pause.IsPaused -= OnPauseStateChanged;
        GameManager.gameover -= OnGameoverStateChanged;
    }

    private void OnPauseStateChanged(bool isPaused)
    {
        // Change the alpha of the CanvasGroup based on the pause state
        if (pause != null) pause.alpha = isPaused ? 1f : 0f;
    }
    private void OnGameoverStateChanged()
    {
        // Change the alpha of the CanvasGroup based on the pause state
        if (gameover != null) gameover.alpha = 1f;
    }
}
