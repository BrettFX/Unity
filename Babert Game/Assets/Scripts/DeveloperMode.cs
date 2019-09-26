using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    private int m_clicks = 0;

    // Count number of clicks and enable developer mode
    public void OnClick()
    {
        m_clicks++;
        Debug.Log("Clicked " + m_clicks + " time(s)!");
    }
}
