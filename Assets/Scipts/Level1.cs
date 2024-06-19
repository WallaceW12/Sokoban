using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject Wall, Box, Player;
    public GameObject[,] map;
    public int col;
    public int row;

    private void Start()
    {
        map = new GameObject[row, col];
        create_wall(map);
        //create_box();
        //create_player();
        //create_grass();

    }
    // Start is called before the first frame update
    public void create_wall(GameObject[,] map)
    {
        Wall = GameObject.FindGameObjectWithTag("Wall");

        for (int i = 0; i <= 5; i++)
        {
            map[0, i] = (GameObject)Instantiate(Wall, new Vector3(i, 0, 0), Quaternion.identity);
        }

        map[1, 1] = (GameObject)Instantiate(Wall, new Vector3(1, 1, 0), Quaternion.identity);

        for (int i = col; i > col - 3; i++)
        {
            map[1, i] = (GameObject)Instantiate(Wall, new Vector3(i, 1, 0), Quaternion.identity);
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
