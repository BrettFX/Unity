using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyOrQuit : MonoBehaviour
{
    // FlyOrQuit
    void OnGUI()
    {
        // Load recycler scene to start over
        if (GUI.Button(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 50, 100, 30), "Fly Again"))
        {
            SceneManager.LoadScene(2);
        }

        // Load main menu
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height - 50, 100, 30), "Main Menu"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
