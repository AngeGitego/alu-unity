using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;       // Drag the player transform here
    public float mouseSensitivity = 100f;
    public bool isInverted = false; // Toggle this in Inspector to test

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide and lock cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply inversion logic
        if (isInverted)
            xRotation += mouseY; // Inverted: move camera up when mouse moves down
        else
            xRotation -= mouseY; // Normal: move camera up when mouse moves up

        // Clamp rotation so we don't flip the camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player body horizontally
        player.Rotate(Vector3.up * mouseX);
    }
}
