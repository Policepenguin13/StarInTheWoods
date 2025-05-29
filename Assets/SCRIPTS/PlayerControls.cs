using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerControls : MonoBehaviour
{
    
    // PLAYER MOVEMENT SCRIPT
    // The direction that the player moves the joystick determines the direction that the player
    // is pointing, how far the joystick is from the centre determines the speed they move forward in
    // that direction.

    // OTHER INPUT STUFF:
    // Press the top thumbpad button to open and close the quest menu
    // Press the right thumbpad button to interact (initiate conversation with NPCs and/or continue
    // said conversation with NPCs


    public CharacterController controller;
    public float speed = 60f;
    // InputSystem_Actions controls;
    Vector2 move;

    public float smoothDampTime = 0.1f;
    float turnSmoothVelocity;

    private void Update()
    {
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (move.x, 0, move.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothDampTime);

            transform.eulerAngles = new Vector3(0f,angle,0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
        //Vector3 m = new Vector3(move.x, 0f, move.y) * Time.deltaTime * speed;

    //if(move != Vector2.zero)
    //    {
    //        float targetAngle = Mathf.Atan2(m.z,m.x) * Mathf.Rad2Deg;
    //        transform.eulerAngles = new Vector3(0f,targetAngle,0f);
    //
    //        transform.Translate(m.x, 0f, m.y);
    //    }

    }

    private void Awake()
    {
       // controls = new InputSystem_Actions();

       // controls.Player.Interact.performed += ctx => Interact();

       // controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
       // controls.Player.Move.canceled += ctx => move = Vector2.zero;
    }

    void Interact()
    {
    transform.localScale *= 1.1f;
    Debug.Log("Interact was pressed!!");
    }

    void OnEnable()
    {
        // controls.Player.Enable();
    }

    void OnDisable()
    {
        // controls.Player.Disable();
    }
}
