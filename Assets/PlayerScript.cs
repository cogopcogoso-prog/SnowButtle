using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Vector2 moveInput;
    public float speed = 5f;
    private Rigidbody rb; 


    private Vector2 mouseInput;
    public float sensitivity = 0.3f;
    public Transform cameraTransform; 

    private float xRotation = 0f;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

  
    public void OnLook(InputValue value)
    {
        mouseInput = value.Get<Vector2>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float mouseX = mouseInput.x * sensitivity;
        float mouseY = mouseInput.y * sensitivity;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);


        Vector3 moveDirection = transform.TransformDirection(direction);

     
        rb.MovePosition(transform.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}
