using UnityEngine;

public class PlanetTranslation : MonoBehaviour
{
    public enum Direction
    {
        UP,
        DOWN
    }

    public Direction m_directionStart = Direction.UP;

    public float speed = 0.5f;
    private int direction;

    // Flag to determine if the planet should render in the center between the upper and lower bounds
    public bool m_anchorCenter = false;

    //Make sure to assign this in the Inspector window
    public Transform m_upperBounds;
    public Transform m_lowerBounds;
    Vector3 m_upperVect3;
    Vector3 m_lowerVect3;

    // Start is called before the first frame update
    void Start()
    {
        // Get position of reference upper and lower bounds to for translation range
        m_upperVect3 = m_upperBounds.position;
        m_lowerVect3 = m_lowerBounds.position;

        // Set the starting direction
        switch (m_directionStart)
        {
            case Direction.UP:
                direction = 1;
                break;

            case Direction.DOWN:
                direction = -1;
                break;

            default:
                direction = 1;
                break;
        }

        // If desired, set the y position of the planet to be anchored to
        // the center of upper and lower bounds (synchonizes side-by-side planet translation)
        if (m_anchorCenter)
        {
            Vector3 prevPos = this.transform.position;
            float normalizedY = (m_upperVect3.y + m_lowerVect3.y) / 2;

            // Instantiate the new position and anchor the y axis to the center for the transform
            Vector3 newPos = new Vector3(prevPos.x, normalizedY, prevPos.z);
            this.transform.position = newPos;
        }
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
