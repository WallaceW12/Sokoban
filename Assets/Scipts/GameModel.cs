using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    private bool m_ReadyForInput;
    public static Player m_Player;
    public static GameModel playerFreeze;
    public static bool isEnded;

 

    // Update is called once per frame

    public static void setPlayer(Player player)
    {
        m_Player = player;
    }
    void Start() {
        isEnded = false;
        playerFreeze = this;
    }
    void Update()
    {
        input();
        if (LevelSelection.isTrigger) {
            isEnded = isEnd();
        }


        if (isEnded)
        {

           // Debug.Log("WINNNNNN!@: " + isEnded);
            this.enabled = false;
            WinMessage.isVisible();

            //ResetPanel.nextButtonVisible();
        }
     

    }
    bool isEnd()
    {
     

      
        Box[] boxes = FindObjectsOfType<Box>();
       
      
        foreach (var box in boxes)
        {
            if (box.name == "Box(Clone)" && !box.isReach)
            {
                 return false;

            }
            
        }

     
        if (boxes.Length == 1) {
            return false;
        }
   
        
        return true;



    }

    void input() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5)
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);

            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    public void initial(int x , int y , int z) {
        m_Player.transform.position = new Vector3(x, y, z);
    }


}
