using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private bool m_volumeToggle = true;

    public Button btnVolume;
    public Sprite spriteVolOn;
    public Sprite spriteVolOff;

    public AudioSource mainAudio;
    public AudioSource crash;
    public AudioSource starSound;

    // Start is called before the first frame update
    void Start()
    {
        // TODO get from player prefs
        m_volumeToggle = true;
    }

    // Toggle the volume state
    public void ToggleVolumeState()
    {
        m_volumeToggle = !m_volumeToggle;
        Sprite targetSprite = m_volumeToggle ? spriteVolOn : spriteVolOff;
        btnVolume.GetComponent<Image>().sprite = targetSprite;

        // Toggle audio assets mute/unmute (needs to be inverse of volume toggle state)
        mainAudio.mute = !m_volumeToggle;
        crash.mute = !m_volumeToggle;
        starSound.mute = !m_volumeToggle;
    }
}
