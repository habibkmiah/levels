using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 70f;
    public float mouseSensitivity = 1000f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse orientation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp vertical rotation

        rotationY += mouseX;

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    void FixedUpdate()
    {
    // Movement
    float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
    float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow
    
    // Detect if the Space key is pressed for moving up
    float moveUp = Input.GetKey(KeyCode.Space) ? 1f : 0f;

    // Detect if the Ctrl key is pressed for moving down
    float moveDown = Input.GetKey(KeyCode.LeftControl) ? 1f : 0f;

    // Get the forward and right vectors, but ignore the vertical rotation
    Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
    Vector3 right = new Vector3(transform.right.x, 0, transform.right.z).normalized;

    // Combine movement directions
    Vector3 movement = (right * moveHorizontal) + (forward * moveVertical) + (Vector3.up * moveUp) + (Vector3.down * moveDown);

    // Apply movement
    transform.position += movement * moveSpeed * Time.deltaTime;
    }
}