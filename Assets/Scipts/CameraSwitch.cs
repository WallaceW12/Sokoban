using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    static GameObject MainCamPanel;
    static GameObject LevelCamPanel;

    static GameObject MainCam;
    static GameObject LevelCam;
    static Camera Main_Cam;
    static Camera Level_Cam;
    private static bool camSwitch = true;


    // Start is called before the first frame update

    private void Start()
    {
        Main_Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Level_Cam = GameObject.Find("LevelCamera").GetComponent<Camera>();

    }
    public static void SwitchCam() {

       // MainCam = GameObject.Find("Main Camera");
       // LevelCam = GameObject.Find("LevelCamera");
      


        camSwitch = !camSwitch;

       // Main_Cam.enabled = camSwitch;
        //Level_Cam.enabled = !camSwitch;

         // MainCam.SetActive(camSwitch);
         //LevelCam.SetActive(!camSwitch);

    } 
    }
 
    // Update is called once per frame
    
