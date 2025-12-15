using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class Gun : MonoBehaviour
{
    [SerializeField] protected string queueName;
     [SerializeField] protected GameObject Ball;
    protected AudioSource gunShot;
    [SerializeField] protected GameManager gay;
    [HideInInspector]public bool isShooting = false;
    protected int reloadTime;
   protected Animator animator;
    protected InputAction fire;
    protected BallMovement ballMovement;
    protected WaitForSeconds reloadWait;

    protected Vector3 pointShot;
   

    protected void Start()
    {
        gay=GameManager.instance;
        reloadTime = PlayerPrefs.GetInt("reloadTime",3);
        reloadWait = new WaitForSeconds(reloadTime);
        ballMovement =Ball.GetComponent<BallMovement>();
        gunShot = GetComponent<AudioSource>();
   animator= GetComponent<Animator>();
        pointShot = transform.GetChild(0).position;
        Gayer();


    }
    protected void Shooting(InputAction.CallbackContext context)
    {

        if (!isShooting)
            StartCoroutine(Shoot());
    }
 
    protected IEnumerator Shoot()
    {


        BallMovement instance = GunPooler.DeQueueObject(queueName);
        instance.gameObject.SetActive(true);
        instance.Movement(transform.position);

        gunShot.Play();
        animator.SetBool("isShooting", true);
        isShooting = true;

        yield return reloadWait;
        animator.SetBool("isShooting", false);
        isShooting = false;


    }
    protected virtual void Gayer()
    {
        fire = gay.Map.Player.Fire;
        fire.performed += Shooting;
        fire.Enable();
    }
     void OnDisable()
    {
            fire.performed -= Shooting;
            fire.Disable();
          }

}
