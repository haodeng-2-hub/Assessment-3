using UnityEngine;

public class PacStudentAutoMover : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 3f;
    [SerializeField] Animator animator;
    [SerializeField] string speedParam = "MovingSpeed";
    [SerializeField] string moveXParam = "MoveX";
    [SerializeField] string moveYParam = "MoveY";
    [SerializeField] AudioSource moveSfx;

    int i;
    Vector2 target;
    bool hasPath;

    void Start()
    {
        hasPath = waypoints != null && waypoints.Length > 0;
        if (hasPath)
        {
            i = 0;
            target = waypoints[i].position;
        }
    }

    void Update()
    {
        if (!hasPath) return;
        Vector2 p = transform.position;
        Vector2 d = target - p;
        float dist = d.magnitude;
        float step = speed * Time.deltaTime;
        if (dist > 0f)
        {
            Vector2 dir = d / dist;
            float move = Mathf.Min(step, dist);
            Vector2 np = p + dir * move;
            transform.position = np;
            if (animator)
            {
                animator.SetFloat(speedParam, speed);
                animator.SetFloat(moveXParam, dir.x);
                animator.SetFloat(moveYParam, dir.y);
            }
            if (moveSfx && !moveSfx.isPlaying) moveSfx.Play();
            if (Mathf.Approximately(move, dist)) Advance();
        }
        else Advance();
    }

    void Advance()
    {
        i = (i + 1) % waypoints.Length;
        target = waypoints[i].position;
    }
}
