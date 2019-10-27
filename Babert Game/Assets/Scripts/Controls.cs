// Jimmy Vegas Unity Tutorial
// This Script will allow you to control the rocket

using UnityEngine;

public class Controls : MonoBehaviour
{
    public const float DEFAULT_SPEED = 8.0f;
    public const float DEFAULT_JUMP_SPEED = 20.5f;
    public const float DEFAULT_GRAVITY = 20.0f;

    private const float ROTATION_SPEED = 5.0f;

    private float speed;
    private float jumpspeed;
    private float gravity;
    private Vector3 moveDirection = Vector3.zero;

    public ParticleSystem rocketParticleSystem;

    void Start()
    {
        // Initialize controls based on developer mode state
        string speed_key = System.Enum.GetName(typeof(DevSettingsManager.DevSetting), 
                                               DevSettingsManager.DevSetting.MOVEMENT_SPEED);
        speed = DeveloperMode.IsDevMode() ? PlayerPrefs.GetFloat(speed_key, DEFAULT_SPEED) : DEFAULT_SPEED;

        string jumpspeed_key = System.Enum.GetName(typeof(DevSettingsManager.DevSetting),
                                               DevSettingsManager.DevSetting.JUMP_SPEED);
        jumpspeed = DeveloperMode.IsDevMode() ? PlayerPrefs.GetFloat(jumpspeed_key, DEFAULT_JUMP_SPEED) : DEFAULT_JUMP_SPEED;

        string gravity_key = System.Enum.GetName(typeof(DevSettingsManager.DevSetting),
                                               DevSettingsManager.DevSetting.GRAVITY);
        gravity = DeveloperMode.IsDevMode() ? PlayerPrefs.GetFloat(gravity_key, DEFAULT_GRAVITY) : DEFAULT_GRAVITY;

        Debug.Log("Movement Speed: " + speed);
        Debug.Log("Jump Speed: " + jumpspeed);
        Debug.Log("Gravity: " + gravity);

        //moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal") + 3);
        moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Horizontal") + 3);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Only move if not paused
        if (!PauseMenu.paused)
        {
            if (!rocketParticleSystem.isPlaying)
            {
                rocketParticleSystem.Play(true);
            }

            CharacterController controller = GetComponent<CharacterController>();
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y += jumpspeed;
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;

            // Ensure a fixed z position value so that updating direction doesn't change the rocket's z-value
            // making the rocket fall behind collidable assets
            moveDirection.z = 0;

            // Move the controller
            controller.Move(moveDirection * Time.deltaTime);

            // Rotate the rocket
            transform.Rotate(ROTATION_SPEED, 0, 0, Space.World);
        }
        else
        {
            if (!rocketParticleSystem.isPaused)
            {
                rocketParticleSystem.Pause(true);
            }
        }
    }    
}
