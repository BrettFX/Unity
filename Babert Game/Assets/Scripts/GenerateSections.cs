using UnityEngine;

public class GenerateSections : MonoBehaviour
{
    public static float sectionY = 30.0f;
    public static float sectionZ = -1.219408f;

    public GameObject section01;
    public GameObject section02;
    public GameObject section03;

    float newXAxis = NextAxis.xAxis;
    int genSection;
    
    Vector3 nextPosition = new Vector3(NextAxis.xAxis, sectionY, sectionZ);

    void OnTriggerEnter(Collider col)
    {
        // Section 01 by default
        GameObject newSection = section01;

        nextPosition = new Vector3(NextAxis.xAxis, sectionY, sectionZ);
        genSection = Random.Range(1, 3);
        newXAxis = NextAxis.xAxis;

        if (genSection == 1)
        {
            newSection = section01;
        }
        if (genSection == 2)
        {
            newSection = section02;
        }
        if (genSection == 3)
        {
            newSection = section03;
        }

        Instantiate(newSection, nextPosition, Quaternion.identity);
        NextAxis.xAxis += 500;
    }
}
