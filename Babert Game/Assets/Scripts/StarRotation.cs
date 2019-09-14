using UnityEngine;

public class StarRotation : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorial
    // This Script will rotate your stars and planet

    public const int SPEED = 2;
    public ParticleSystem starParticleSystem;

    void Update()
    {
        if (!PauseMenu.paused)
        {
            if (!starParticleSystem.isPlaying)
            {
                starParticleSystem.Play(true);
            }

            transform.Rotate(0, SPEED, 0, Space.World); 
        }
        else
        {
            if (!starParticleSystem.isPaused)
            {
                starParticleSystem.Pause(true);
            }
        }
    }
}
