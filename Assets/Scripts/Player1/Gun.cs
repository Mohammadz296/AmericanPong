using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class Gun : MonoBehaviour
{
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
        reloadTime = PlayerPrefs.GetInt("reloadTime",3);
        reloadWait = new WaitForSeconds(reloadTime);
        ballMovement =Ball.GetComponent<BallMovement>();
        gunShot = GetComponent<AudioSource>();
   animator= GetComponent<Animator>();
        Gayer();


    }
    protected void Shooting(InputAction.CallbackContext context)
    {

        if (!isShooting)
            StartCoroutine(Shoot());
    }
    protected IEnumerator Shoot()
    { 
            pointShot = transform.GetChild(0).position;
            Instantiate(Ball, pointShot, Quaternion.identity);
            ballMovement.timer = 0;
          
            gunShot.Play();
            animator.SetBool("isShooting",true);
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
