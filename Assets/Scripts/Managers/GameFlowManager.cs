using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gamePlayScreen;

    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            FindAnyObjectByType<UIManager>().UpdatePauseScreen();
            pauseScreen.SetActive(true);
            gamePlayScreen.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            gamePlayScreen.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        TogglePause();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
