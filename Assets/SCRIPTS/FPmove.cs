using UnityEngine;

public class FPmove : MonoBehaviour
{
    // Player movement script, made using Brackey's "FIRST PERSON MOVEMENT in
    // Unity - FPS Controller" video, and edited from there.

    public CharacterController controller;

    InputSystem_Actions controls; 
    // no idea why this is giving me the warning
    // CS0649 Field 'FPmove.controls' is never assigned to, and will always have it's default value null
    // when it gets assigned in Awake and none of the other scripts give this warning

    Vector2 go;

    public bool CanMove = true;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 Velocity;
    bool isGrounded;
    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.FPactions.Move.performed += ctx => go = ctx.ReadValue<Vector2>();
        controls.FPactions.Move.canceled += ctx => go = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");

        float x = go.x;
        float z = go.y;

        if (CanMove == false)
        {
            x = 0f;
            z = 0f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        Velocity.y += gravity * Time.deltaTime;

        controller.Move(Velocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        controls.FPactions.Enable();
    }
    private void OnDisable()
    {
        controls.FPactions.Disable();
    }
}
