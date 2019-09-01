using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyOrQuit : MonoBehaviour
{
    // Load recycler scene to start over
    public void FlyAgain()
    {
        SceneManager.LoadScene(2);
    }

    // Load main menu
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
