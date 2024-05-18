using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Camera mainCamera;
    
    public float speed = 5.0f;
    public float mouseSensitivity = 100.0f;
    
    public bool canJump = true;
    public float jumpForce = 10.0f;
    bool isGrounded = false;
    
    public float groundCheckDistance = 0.1f;
    public LayerMask groundMask;
    
    private float verticalVelocity = 0.0f;
    private float gravity = -9.81f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * horizontal + transform.forward * vertical + transform.up * verticalVelocity;
        controller.Move(move * speed * Time.deltaTime);
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.Rotate(Vector3.up, mouseX * mouseSensitivity * Time.deltaTime);

        // Camera
        Vector3 cameraRotation = mainCamera.transform.localEulerAngles;
        cameraRotation.x -= mouseY * mouseSensitivity * Time.deltaTime;
        
        if (cameraRotation.x > 180) {
            cameraRotation.x -= 360;
        }

        // Clamp
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90.0f, 90.0f);
        mainCamera.transform.localEulerAngles = cameraRotation;
        
        // Sprint
        if(Input.GetKey(KeyCode.LeftShift) && vertical > 0.0f) {
            speed = 15.0f;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 85.0f, 16f * Time.deltaTime);
        } else {
            speed = 5.0f;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 60.0f, 16f * Time.deltaTime);
        }
        
        // Ground check
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, out hit, groundCheckDistance, groundMask);
        Debug.DrawRay(transform.position, -Vector3.up * groundCheckDistance, Color.red);
        
        // Jump
        if (canJump && Input.GetButtonDown("Jump") && isGrounded) {
            verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity
        if (!isGrounded) {
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Reset vertical velocity if grounded
        if (isGrounded && verticalVelocity < 0) {
            verticalVelocity = 0;
        }

        if(Input.GetKeyDown(KeyCode.F)) //F tuþu ile objelerle etkileþime geçme
        {
            Ray ray= mainCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hitiki;
            if(Physics.Raycast(ray, out hitiki))
            {
                if(hitiki.collider.TryGetComponent(out IInteractable interactObject))
                {
                    interactObject.Interact();
                }
            }

        }
    }
}
