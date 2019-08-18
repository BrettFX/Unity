using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 14.0f;
    public float cameraY = 12.0f;

    private float targetX;
    public float cameraPosition = 17.0f;

    private Vector3 follow;

    // Update is called once per frame
    void Update()
    {
        targetX = target.position.x - 2;
        follow = new Vector3(targetX + cameraPosition, 20f, 0f);
        transform.position = follow;
    }
}
