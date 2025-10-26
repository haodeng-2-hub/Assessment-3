using UnityEngine;

public class PacStudentCollision : MonoBehaviour
{
    public AudioSource eatSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pellet"))
        {
            if (eatSound != null) eatSound.Play();
            Destroy(other.gameObject);
            GameManager.Instance.AddScore(10);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall!");
        }
    }
}
