using UnityEngine;

public class BallMovement : MonoBehaviour
{
    float Speed = 10;
  Rigidbody2D rb;
  AudioSource bounce;
    [SerializeField]  string playerTag;
   float DeathRate = 10;
   [HideInInspector] public  float timer;
    
    Vector2 Move;

    // Start is called before the first frame update
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bounce = GetComponent<AudioSource>();
        Speed = PlayerPrefs.GetInt("speed", 10);
        DeathRate = PlayerPrefs.GetInt("deathRate", 10);
        Movement();


    }

    // Update is called once per frame
     void Update()
    {
        TimedDeath();

    }
     void Movement()
    {
        Move.x = Random.Range(0, 2) == 0 ? -1 : 1;
        Move.y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = Move * Speed;
    }
    public void Kill()
    {
        Destroy(this.gameObject);

    }
     void TimedDeath()
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
        if (collision.gameObject.CompareTag(playerTag))
        {
            Kill();
        }
    }
}
