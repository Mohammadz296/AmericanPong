using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunForPlayer2 : Gun
{
    void Update()
    {

        if (!isShooting)
            StartCoroutine(Shoot(KeyCode.U));



    }

    
    
}
