using UnityEngine;


public class Player : PlayeController
{
    void Update()
    {
        if (Input.GetKey(KeyCode.I))    
            movement.y = 1;
        else if (Input.GetKey(KeyCode.K))    
           movement.y = -1;     
        else       
            movement.y = 0;      
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreManager.RightAddScore(1);
            PointSound.Play();


        }


    }


}
