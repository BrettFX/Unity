using UnityEngine;

public class PlanetTranslation : MonoBehaviour
{
    public float speed = 0.5f;
    private int direction = 1;

    //Make sure to assign this in the Inspector window
    public Transform m_upperBounds;
    public Transform m_lowerBounds;
    Collider m_Collider;
    Vector3 m_upperVect3;
    Vector3 m_lowerVect3;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Collider from the GameObject this script is attached to
        m_Collider = GetComponent<Collider>();

        // Get position of reference upper and lower bounds to for translation range
        m_upperVect3 = m_upperBounds.position;
        m_lowerVect3 = m_lowerBounds.position;
    }

    // Update is called once per frame
    void Update()
    {  
        // If the first GameObject's Bounds contains the Transform's position, bounce the object back
        if (this.transform.position.y >= m_upperVect3.y || this.transform.position.y <= m_lowerVect3.y)
        {
            direction *= -1;
        }

        float delta = speed * direction;
        transform.Translate(0, delta, 0, Space.World);
    }
}
