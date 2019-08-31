using UnityEngine;

public class NextAxis : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorials
    // The below are the axis tracker and the random generator
    public const float START_X = 67.0f;
    public static float xAxis = START_X; // 232.2674f
    float internalAxis;

    void Update()
    {
        internalAxis = xAxis;
    }  
}
