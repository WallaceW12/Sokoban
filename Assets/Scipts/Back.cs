using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Start is called before the first frame update
    static GameObject BackPanel;
    static GameObject LevelMenu;
    static GameObject ResetMenu;
    public static bool Visible;

 



    private void Start()
    {
        LevelMenu = GameObject.Find("CanvasLevel");
        BackPanel = GameObject.Find("CanvasBack");
    
        BackPanel.SetActive(false);
 
    }

    public void returnMenu()
    {

       // SceneManager.LoadScene("MenuScene");

        CameraSwitch.SwitchCam();

        LoadMap.Destroy();

        LevelMenu.SetActive(true);
        BackPanel.SetActive(false);
        
        WinMessage.notVisible();

       

        Visible = false;

    }
    public static void isVisible() // set the reset panel to be visible
    {

        Visible = true;
        BackPanel.SetActive(true);
    }


}
