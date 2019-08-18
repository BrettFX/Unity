using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = -35.0f;
    public float cameraY = -5.0f;

    private float targetX;
    public float xOffset = 10.0f;

    private Vector3 follow;

    // Update is called once per frame
    void Update()
    {
        targetX = target.position.x - 2;
        follow = new Vector3(targetX + xOffset, cameraY, distance);
        transform.position = follow;
    }
}
