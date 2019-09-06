using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTranslation : MonoBehaviour
{
    public const float SPEED = 0.1f;
    private int direction = 1;

    //Make sure to assign this in the Inspector window
    public Transform m_NewTransform;
    Collider m_Collider;
    Vector3 m_Point;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This shit is working...");
        //Fetch the Collider from the GameObject this script is attached to
        m_Collider = GetComponent<Collider>();
        //Assign the point to be that of the Transform you assign in the Inspector window
        m_Point = m_NewTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetTransform = transform.GetComponent<Vector3>();
        //Texture3D bounds = relativeTo.GetComponent<Texture3D>();

        //if (targetTransform.y >= bounds.height)
        //{
        //    direction = -1;
        //}
        //else if (targetTransform.y == 0)
        //{
        //    direction = 1;
        //}

        //If the first GameObject's Bounds contains the Transform's position, output a message in the console
        if (m_Collider.bounds.Contains(m_Point))
        {
            Debug.Log("Bounds contain the point : " + m_Point);
        }

        float delta = SPEED * direction;
        transform.Translate(0, delta, 0, Space.World);
    }
}
