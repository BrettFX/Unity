using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float cameraZ = 0.0f;
    private float cameraY = 0.0f;

    private float targetX;
    public float xOffset = 10.0f;

    private Vector3 follow;

    //Make sure to assign this in the Inspector window
    public Transform m_upperBounds;
    public Transform m_lowerBounds;
    Vector3 m_upperVect3;
    Vector3 m_lowerVect3;

    private void Start()
    {
        // Get position of reference upper and lower bounds to place camera y within center of
        m_upperVect3 = m_upperBounds.position;
        m_lowerVect3 = m_lowerBounds.position;

        // Set Camera Y to be centered between upper and lower bounds 
        Vector3 prevPos = this.transform.position;
        cameraY = (m_upperVect3.y + m_lowerVect3.y) / 2;

        // Set Camera Z to be the negative distance between the upper bounds and lower bounds to zoom out
        cameraZ = -Distance(m_upperVect3, m_lowerVect3);

        // Instantiate the new position and anchor the y axis to the center for the transform (camera)
        Vector3 newPos = new Vector3(prevPos.x, cameraY, cameraZ);
        this.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        targetX = target.position.x;
        follow = new Vector3(targetX + xOffset, cameraY, cameraZ);
        transform.position = follow;
    }

    // Compute the distance between two points (using distance formula)
    private float Distance(Vector3 point1, Vector3 point2)
    {
        float xCalc = Mathf.Pow(point2.x - point1.x, 2);
        float yCalc = Mathf.Pow(point2.y - point1.y, 2);
        return Mathf.Sqrt(xCalc + yCalc);
    }
}
