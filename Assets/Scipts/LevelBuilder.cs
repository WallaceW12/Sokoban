using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject Wall, Box, Player;
    public GameObject[,] map;
    public int col;
    public int row;

    private void Start()
    {
        create_wall();
        //create_box();
        //create_player();
        //create_grass();

    }
    // Start is called before the first frame update
    public void create_wall()
    {

        map = new GameObject[row, col];
        Wall = GameObject.FindGameObjectWithTag("Wall");

        for (int i = 2; i <= col; i++)
        {
            map[0, 0] = (GameObject)Instantiate(Wall, new Vector3(i, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i <= 2; i++)
        {
            map[1, i] = (GameObject)Instantiate(Wall, new Vector3(1, i, 0), Quaternion.identity);
        }
      
    }

    // Update is called once per frame
    public void create_box()
    {
        Box = GameObject.FindGameObjectWithTag("Box");
    }
    public void create_player()
    {

    }
    public void create_grass()
    {

    }
}
