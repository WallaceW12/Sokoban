using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ResetPanel : MonoBehaviour
{
    static GameObject resetPanel;
    static GameObject resetButton;
 
 
    static GameObject nxt;
 
    public static bool Visible;


   
    LoadMap lm;
    // Start is called before the first frame update

    public ResetPanel()
    {
 
        Visible = false;

    }
    private void Start()
    {
        resetPanel = GameObject.Find("CanvasResetPanel");
        resetButton = GameObject.Find("Reset");
        nxt = GameObject.Find("Next");
        lm = new LoadMap();

        nxt.SetActive(false);
        resetPanel.SetActive(false);
        

    }
    public static void isTrigger() // set the reset panel to be visible
    {
        if (!Visible) {
            resetPanel.SetActive(true);
            resetButton.SetActive(true);
            nxt.SetActive(false);
        }

    }

    public static void isTriggerEnd() // set the reset panel to be invisible
    {
       // Debug.Log("isTriggerEnd triggered: visible:? " + Visible);
        if (Visible) {
            nxt.SetActive(false);
            resetButton.SetActive(false);
            resetPanel.SetActive(false);
            Visible = false;
           // Debug.Log("set invisible");
        }
         
      //  Debug.Log("visible? " + Visible);
    } 

    public static void nextButtonVisible() { // set the button to be seen when the game is complete
        nxt.SetActive(true);
    }

    public void ButtonReset() { // execute reset function
         lm.resetLevel();
        
    }


    /*public void ButtonNext() {  


        lm.nextLevel();
    }*/

}
