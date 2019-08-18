// Jimmy Vegas Unity Tutorial
// This Script will allow you to control the rocket

using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpspeed = 20.5f;
    public float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal") + 3);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y += jumpspeed;
            }

        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y += jumpspeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
