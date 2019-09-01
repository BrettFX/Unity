using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = -27.5f;
    public float cameraY = 0.0f;

    private float targetX;
    public float xOffset = 10.0f;

    private Vector3 follow;

    // Update is called once per frame
    void Update()
    {
        targetX = target.position.x;
        follow = new Vector3(targetX + xOffset, cameraY, distance);
        transform.position = follow;
    }
}
