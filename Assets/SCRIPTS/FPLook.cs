using UnityEngine;

public class FPLook : MonoBehaviour
{
    // Player movement script, made using Brackey's "FIRST PERSON MOVEMENT in Unity - FPS Controller" video.
    // Initially made using keyboard inputs, changed (hopefully) to work using controller inputs at well.
    // Need to understand the ctx and vectors of the controller input though


    public float mouseSensitivity = 100f;

    public Transform PlayerBody;

    float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
