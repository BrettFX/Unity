using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Jimmy Vegas Unity Tutorial

    //Main Menu
    public void PlayGame()
    {
        // Load main flight scene
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
