using UnityEngine;

public class PlayeController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioSource PointSound;

    // Start is called before the first frame update

    public float Speed ;
    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");

    }
    protected void FixedUpdate()
    {
        if (movement.y == 0)
            rb.linearVelocity = Vector2.zero;
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BallForPlayer2"))
        {

            scoreManager.LeftAddScore(1);
            PointSound.Play();
        }

    }

}
