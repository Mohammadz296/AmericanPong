using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveForPlayer2 : BallMovement
{
   
    
      void OnCollisionEnter2D(Collision2D collision)
    {
        bounce.Play();
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            Kill();
        }
    }
}
