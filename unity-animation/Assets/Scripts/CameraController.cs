using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform player;        // Player reference
    public Vector3 offset = new Vector3(0, 5, -7); // Default camera offset

    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;
    public bool isInverted = false;

    private float yaw;   // Left/Right rotation
    private float pitch; // Up/Down rotation

    void Start()
    {
        // Initialize rotation based on current transform
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        // Lock cursor for better camera control
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // --- Mouse Input ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= isInverted ? -mouseY : mouseY;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // Prevent flipping over

        // --- Camera Rotation ---
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // --- Camera Position ---
        Vector3 desiredPosition = player.position + rotation * offset;
        transform.position = desiredPosition;

        // --- Look at Player ---
        transform.LookAt(player.position + Vector3.up * 1.5f); // Aim slightly above player's feet
    }
}
