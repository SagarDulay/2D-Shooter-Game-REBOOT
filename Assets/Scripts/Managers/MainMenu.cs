using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject instructionsScreen;
    [SerializeField] private GameObject mainMenuScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay Screen");
    }

    public void OpenInstructions()
    {
        instructionsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        instructionsScreen.SetActive(false);
    }

    public void CloseInstructions()
    {
        instructionsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
