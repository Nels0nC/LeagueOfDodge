using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{

    public float moveSpeed = 5f;
     private Rigidbody2D body;
     private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
