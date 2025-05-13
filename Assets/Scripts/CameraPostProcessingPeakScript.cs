using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraPostProcessingPeakScript : MonoBehaviour
{
 
     UniversalAdditionalCameraData cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>().GetComponent<UniversalAdditionalCameraData>();

        int f = PlayerPrefs.GetInt("isProcessing", 2);
        if (f ==1)
        {
         
           cam.renderPostProcessing = false;
        }
        else
            cam.renderPostProcessing = true;

    }

   
}
