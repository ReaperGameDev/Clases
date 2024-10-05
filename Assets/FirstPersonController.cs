using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 6.0f; // Velocidad del jugador
    public float mouseSensitivity = 2.0f; // Sensibilidad del mouse
    public float jumpHeight = 1.0f; // Altura del salto
    public float gravity = -9.81f; // Gravedad del jugador

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform cameraTransform; // Referencia a la cámara del jugador
    private float verticalRotation = 0f; // Rotación vertical de la cámara

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Movimiento del jugador
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resetea la velocidad vertical al estar en el suelo
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Rotación de la cámara (mouse)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limitar la rotación vertical

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Rotar el cuerpo del jugador
    }
}
