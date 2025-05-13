using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public GameObject Ball;
    public AudioSource gunShot;
    [HideInInspector]public bool isShooting = false;
    public int reloadTime;
   public Animator animator;
    BallMovement ballMovement;
  
    protected Vector3 pointShot;
    // Update is called once per frame

     protected void Start()
    {
        reloadTime = PlayerPrefs.GetInt("reloadTime",3);
       ballMovement=Ball.GetComponent<BallMovement>();
    }
     void Update()
    {
        
        if (!isShooting)
            StartCoroutine(Shoot(KeyCode.Q));
        


    }
    protected virtual IEnumerator Shoot(KeyCode k)
    {
        if (Input.GetKeyDown(k))
        {
            pointShot = transform.GetChild(0).position;
            Instantiate(Ball, pointShot, Quaternion.identity);
            ballMovement.timer = 0;
          
            gunShot.Play();
            animator.SetBool("isShooting",true);
            isShooting = true;
         
            yield return new WaitForSeconds(reloadTime);
            animator.SetBool("isShooting", false);
        
            isShooting = false;


        }
    }
  
}
