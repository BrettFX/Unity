using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = -17.0f;
    public float cameraY = 12.0f;

    private float targetX;
    public float xOffset = 0.0f;

    private Vector3 follow;

    // Update is called once per frame
    void Update()
    {
        targetX = target.position.x - 2;
        follow = new Vector3(targetX + xOffset, cameraY, distance);
        transform.position = follow;
    }
}
