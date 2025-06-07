using System.Threading;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPLook : MonoBehaviour
{
    // Player looking script, made using Brackey's "FIRST PERSON MOVEMENT in Unity - FPS Controller" video.
    // Initially made for keyboard input, changed to work using controller inputs as well.
    // Need to understand the ctx and vectors of the controller input though, maybe

    InputSystem_Actions controls;

    Vector2 look;

    public bool UsingMouse = false;

    public float Sensitivity = 100f;

    public Transform PlayerBody;

    float xRotation = 0f;

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.FPactions.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.FPactions.Look.canceled += ctx => look = Vector2.zero;

        // controls.FPactions.InteractNext.performed += ctx => InteractNext();
        // ^ that code was moved to the FPbutton script
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingMouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Vector2 l = new Vector2 (look.x, look.y) * Sensitivity * Time.deltaTime;

            xRotation -= l.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * l.x);
        }
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
