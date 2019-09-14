using UnityEngine;

public class PlanetRotation001 : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorial
    // This Script will rotate your stars and planet

    public const int SPEED = 1;

    void Update()
    {
        if (!PauseMenu.paused)
        {
            transform.Rotate(0, SPEED, 0, Space.World); 
        }
    }
}
