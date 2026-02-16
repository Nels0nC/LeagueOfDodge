using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4f;
    public float lifetime = 3f;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }

        //Destroy(gameObject);
    }
}
