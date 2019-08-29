using UnityEngine;
using UnityEngine.SceneManagement;

public class Recycle : MonoBehaviour
{
    //Recycle
    void Start()
    {
        // Reset score
        ScoringSystem.score = 0;

        // Load main flight scene
        SceneManager.LoadScene(1);
    }
}
