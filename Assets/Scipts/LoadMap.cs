using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    private GameObject tmp;
    public GameObject objWall, objBox, objPlayer, objGrass, objTarget, objNull;

    private static int height;
    private static int width;
    public static GameObject[,] map;
    public GameModel p;
    public Player clone;
    public static int currentLevel;
    public static bool loadedmap;
    GameObject nxt;


      private void Start()
        {
          
        height = 15;
        width = 15;
        //setLevel(1);
       // SceneManager.LoadSceneAsync("LevelScene");
    }


    public static void Destroy()
    {


        //CameraSwitch.SwitchCam();
        GameObject[] list = SceneManager.GetSceneByName("LevelScene").GetRootGameObjects(); ;
        GameObject levelCam = GameObject.Find("LevelCamera");
        

        //int num = 0;
        foreach (GameObject obj in list)
        {
           
                Destroy(obj);
            
 
       
        }

        for (int i = 0; i <  height; i++) {
            for (int j = 1; j <  width; j++) {
                 map[i, j] = null;
            }
        }
        GameModel.isEnded = false;

       
        // Debug.Log(currentLevel);

    }
    /*public void nextLevel() {
        nxt = GameObject.Find("Next");
        nxt.SetActive(false);
        GameModel.playerFreeze.enabled = true;


        LoadMap.Destroy();



        //setLevel(currentLevel % 4);
    }*/
    public void resetLevel()
    {
         
        GameObject tmp ;
 
        // Destroy();
 

        tmp = new GameObject();

        Box[] tmpBox ;
        Player[] tmpPlayer;

        GameModel.playerFreeze.enabled = true;
        tmpBox = GameObject.FindObjectsOfType<Box>();
        tmpPlayer = GameObject.FindObjectsOfType<Player>();


        foreach (Box box in tmpBox)
        {
            if (box.name == "Box(Clone)" )
            {
               // Debug.Log("Box: " + box.name + "Pos: " + box.originPos);

                box.transform.position = box.originPos;

                box.isReturn = true;
            }
        }

       
        foreach (Player clone in tmpPlayer)
        {
            
            if (clone.name == "Player(Clone)")
            {
              //  Debug.Log("Player: " + clone.name + "Player: " + clone.originPos);
                clone.transform.position = clone.originPos;
                clone.isReturn = true;

            }

        }
        WinMessage.notVisible();



    }

    public void setLevel(int level) {
        string levelFile = File.ReadAllText("Assets/Maps/level" + level + ".txt");
        currentLevel = level;
        loadMap(levelFile);
        loadedmap = true;
    }


    void loadMap(string level)
    {
        string input = level;
        objGrass = GameObject.FindGameObjectWithTag("Grass");
  

        map = new GameObject[width, height];

        int i = height-1, j = 0;

        foreach (var row in input.Split('\n')) {
            foreach (var col in row.Trim().Split(' '))
            {
                if (col.Trim() != "43")
                {
                    tmp = objectReturn(int.Parse(col.Trim()));
                    
                    map[i, j] = (GameObject)Instantiate(tmp, new Vector3(j, i, 0), Quaternion.identity);



                    if (int.Parse(col.Trim()) == 2)
                    {
                        clone = GameObject.Find("Player(Clone)").GetComponent<Player>();
                        GameModel.setPlayer(clone);

                        clone = GameObject.FindObjectOfType<Player>();

                        if (clone.name == "Player(Clone)")
                        {
                            clone.originPos = clone.transform.position;
                            clone.isReturn = true;

                        }



                    }
                }
                else {
                    map[i, j] = (GameObject)Instantiate(objTarget, new Vector3(j, i, 0), Quaternion.identity);

                    map[i, j] = (GameObject)Instantiate(objBox, new Vector3(j, i, 0), Quaternion.identity);

                }




                if (int.Parse(col.Trim()) != 5) {
                    map[i, j] = (GameObject)Instantiate(objGrass, new Vector3(j, i, 0), Quaternion.identity);

                }
               // map[i, j].transform.parent = GameObject.Find("LevelScene").GetComponent<GameObject>().transform;

                j++;

            }
            j = 0;
            i--;
        }

    }
    //0 = wall, 1 = box, 2 = player, 3=grass, 4 = target
    GameObject objectReturn(int objNum) {

        switch (objNum)
        {
            case 0:
                objWall = GameObject.FindGameObjectWithTag("Wall");
                return objWall;
            case 1:
                objBox = GameObject.FindGameObjectWithTag("Box");
                return objBox;
            case 2:
                objPlayer = GameObject.FindGameObjectWithTag("Player");
                return objPlayer;
            case 3:
                objGrass = GameObject.FindGameObjectWithTag("Grass");
                return objGrass;
            case 4:
                objTarget = GameObject.FindGameObjectWithTag("Target");
                return objTarget;
            case 5:
                objNull = GameObject.FindGameObjectWithTag("Null");
                return objNull;

            default: break;
        }
        return tmp;
    }


}
