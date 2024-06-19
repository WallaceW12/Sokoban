using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelSelection : MonoBehaviour
{
    static LoadMap access;
    public static bool isTrigger;
    
    static GameObject backPanel;
    static GameObject mainMenu;


    // Start is called before the first frame update


    private void Start()
    {
        access = new LoadMap();

        mainMenu = GameObject.Find("CanvasLevel");

    }
  
    public static void trigger() {
        
        string name = EventSystem.current.currentSelectedGameObject.name;
      
            //CameraSwitch.SwitchCam();
 
            access.setLevel(int.Parse(name));

            ResetPanel.Visible = true;
          //  resetPanel = GameObject.Find("CanvasResetPanel");
            //backPanel = GameObject.Find("CanvasBack");
            isTrigger = true;
            GameModel.playerFreeze.enabled = true;
            mainMenu.SetActive(false);

          

         
        //   backPanel.SetActive(true);
        //resetPanel.SetActive(true);

    }

  
    public static void LoadScene() {
        SceneManager.LoadSceneAsync("LevelScene");

    }



}


//        Debug.Log("reached");
//access.setLevel(int.Parse(name));