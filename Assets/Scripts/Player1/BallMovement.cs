using UnityEditor.UIElements;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [HideInInspector] public float Speed = 10;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] protected AudioSource bounce;

    [HideInInspector] public float DeathRate = 10;
    [HideInInspector] public float timer;
    
    Vector2 Move;

    // Start is called before the first frame update
     protected void Start()
    {
        Speed = PlayerPrefs.GetInt("speed", 10);
        DeathRate = PlayerPrefs.GetInt("deathRate", 10);
        Movement();


    }

    // Update is called once per frame
    protected void Update()
    {
        TimedDeath();

    }
    protected void Movement()
    {
        Move.x = Random.Range(0, 2) == 0 ? -1 : 1;
        Move.y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = Move * Speed;
    }
    public void Kill()
    {
        Destroy(this.gameObject);

    }
    protected void TimedDeath()
    {
        if (timer < DeathRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Kill();
            timer = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bounce.Play();
        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            Kill();
        }
    }
}
