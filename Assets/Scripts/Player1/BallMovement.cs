using UnityEngine;

public class BallMovement : MonoBehaviour
{
    float Speed = 10;
  Rigidbody2D rb;
  AudioSource bounce;
    [SerializeField]  string playerTag;
    [SerializeField] string QueueName;
   float DeathRate = 10;
  float timer;
    
    Vector2 Move;

    // Start is called before the first frame update

     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bounce = GetComponent<AudioSource>();
        Speed = PlayerPrefs.GetInt("speed", 10);
        DeathRate = PlayerPrefs.GetInt("deathRate", 10);
    }

    // Update is called once per frame
     void Update()
    {
        TimedDeath();

    }
    //other than the rest of the movement this specific code was taken from a video made by BMo as I did not know how to move the ball https://www.youtube.com/watch?v=YHSanceczXY
    public void Movement(Vector3 pos)
    {
     
transform.position=pos;
        Move.x = Random.Range(0, 2) == 0 ? -1 : 1;
        Move.y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = Move * Speed;
    }
    public void Kill()
    {

        GunPooler.EnqueueObject(this,QueueName);
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
        if( bounce.enabled && isActiveAndEnabled)
        bounce.Play();
        if (collision.gameObject.CompareTag(playerTag))
        {
            Kill();
        }
    }
}
