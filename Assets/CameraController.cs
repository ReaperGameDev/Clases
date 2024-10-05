using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 2f;
    public Vector2 sensitivity = new Vector2(4f, 4f);
    public float minYAngle = -40f;
    public float maxYAngle = 85f;

    private Vector2 rotation = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        rotation.x += Input.GetAxis("Mouse X") * sensitivity.x;
        rotation.y -= Input.GetAxis("Mouse Y") * sensitivity.y;
        rotation.y = Mathf.Clamp(rotation.y, minYAngle, maxYAngle);

        transform.position = target.position - transform.forward * distanceFromTarget;
        transform.LookAt(target);
    }

    void Update()
    {
        transform.position = target.position - transform.forward * distanceFromTarget;
        transform.eulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}