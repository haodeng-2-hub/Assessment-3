using UnityEngine;

public class PacStudent : MonoBehaviour
{
    public float speed = 5f;
    public float eatRange = 0.25f;
    public AudioSource audioSource;
    public AudioClip eatPelletSFX;

    Rigidbody2D rb;
    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) dir = Vector2.up;
        else if (Input.GetKey(KeyCode.S)) dir = Vector2.down;
        else if (Input.GetKey(KeyCode.A)) dir = Vector2.left;
        else if (Input.GetKey(KeyCode.D)) dir = Vector2.right;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        EatPelletProximity();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pellet"))
            EatPellet(other.gameObject);
        else if (other.CompareTag("Ghost"))
            GameManager.Instance?.LoseLife();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ghost"))
            GameManager.Instance?.LoseLife();
    }

    void EatPellet(GameObject pellet)
    {
        Destroy(pellet);
        if (audioSource && eatPelletSFX) audioSource.PlayOneShot(eatPelletSFX);
        GameManager.Instance?.AddScore(10);
    }

    void EatPelletProximity()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, eatRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].CompareTag("Pellet"))
            {
                EatPellet(hits[i].gameObject);
                break;
            }
        }
    }
}
