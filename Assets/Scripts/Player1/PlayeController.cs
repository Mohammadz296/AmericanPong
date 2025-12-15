using UnityEngine;
using UnityEngine.InputSystem;
public class PlayeController : MonoBehaviour
{

    protected AudioSource PointSound;
    [SerializeField] protected float Speed;
    [SerializeField] protected string ballTag;

    protected InputAction move;
    bool isLocal = true;
    InputAction pause;
    protected Rigidbody2D rb;
    protected Vector2 movement;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PointSound = GetComponent<AudioSource>();

    }

    protected void Update()
    {
        if (isLocal)
            movement = move.ReadValue<Vector2>();
    }
    protected void FixedUpdate()
    {
        if (movement.y == 0)
            rb.linearVelocity = Vector2.zero;
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ballTag))
        {

            ScoreManager.instance.LeftAddScore(1);
            PointSound.Play();
        }

    }
    private void Pause(InputAction.CallbackContext context)
    {
        GameManager.instance.PauseGame();
    }
    private void OnEnable()
    {

        move = GameManager.instance.Map.Player.Movement;
        pause = GameManager.instance.Map.Player.Pause;

        GameManager.instance.Map.Player.Pause.performed += Pause;

        move.Enable();
        pause.Enable();
    }
    private void OnDisable()
    {
        GameManager.instance.Map.Player.Pause.performed -= Pause;
        move.Disable();
        pause.Disable();

    }
    public void NotLocal()=> isLocal = false;
    
    public void IsLocal()=> isLocal=true;   
   
}
