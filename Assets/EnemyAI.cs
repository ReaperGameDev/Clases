using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float stoppingDistance = 1.5f;

    public bool activateEnemy;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (activateEnemy)
        {
            Vector3 direction = player.position - transform.position;

            float distance = direction.magnitude;

            if (distance > stoppingDistance)
            {
                direction.Normalize();
                Vector3 movement = direction * speed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + movement);
            }
        }
    }
}