using UnityEngine;


public class Player : PlayeController
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ballTag))
        {

            ScoreManager.instance.RightAddScore(1);
            PointSound.Play();
        }

    }

    private void OnEnable()
    {
        move = GameManager.instance.Map.Player2.Movement;
        move.Enable();

    }
    private void OnDisable()
    {
        move.Disable();

    }
}
