using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource; 
    // Start is called before the first frame update
 
   public void PlaySFX()
    {
        audioSource.Play();
    }
}
