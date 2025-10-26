using UnityEngine;

public class GhostRandomMove : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float changeDirTime = 0f;
    private float changeDirInterval = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickRandomDirection();
    }

    void Update()
    {
        if (Time.time > changeDirTime)
        {
            PickRandomDirection();
            changeDirTime = Time.time + changeDirInterval;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void PickRandomDirection()
    {
        int r = Random.Range(0, 4);
        switch (r)
        {
            case 0: direction = Vector2.up; break;
            case 1: direction = Vector2.down; break;
            case 2: direction = Vector2.left; break;
            case 3: direction = Vector2.right; break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PickRandomDirection();
        }
    }
}
