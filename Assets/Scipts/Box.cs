using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isReach;
    public Vector3 originPos;
     
    public bool isReturn;

    public Box() {

        isReach = false;
        isReturn = true;
        
    }
    private void Start()
    {
        originPos = transform.position;

    }
    private void Update()
    {
        
        isReturn = isReturned();
        isReach = isReached();
       // Debug.Log("BOx reached ??" + isReach);
    }
    // Start is called before the first frame update
    public bool Move(Vector3 pos ,Vector2 direction) {

        if (boxIsBlocked(transform.position,direction))
        {
            return false;
        }
        else {
            transform.Translate(direction);
            return true;
        }
    }
 

    public bool boxIsBlocked(Vector3 pos, Vector2 direction) {

        Vector2 newPos = new Vector2(pos.x, pos.y) + direction;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls) {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes) {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y) {
                return true;
            }

        }
        return false;
    }

    private bool isReturned()
    {
        GameObject[] Boxes = GameObject.FindGameObjectsWithTag("Box");

        foreach (var box in Boxes)
        {
            if (box.transform.position == originPos) {
                return true;
            }
        }

  
        return false;
    }
    private bool isReached() {
        GameObject[] Target = GameObject.FindGameObjectsWithTag("Target");
        Color32 brown = new Color32(133, 72, 37,255);
        Color32 white = new Color32(255, 255, 255, 255);

        foreach (var tar in Target) {
            if ((tar.transform.position.x == this.transform.position.x) && (tar.transform.position.y == this.transform.position.y)) {
             
                this.GetComponent<SpriteRenderer>().material.color = brown;
                
                return true;
            }
        }
        this.GetComponent<Renderer>().material.color = white;
       
        return false;
    }
  

    /*  void Start()
     {
         gameObject.GetComponent<Player>().enabled = false;
     }*/
}
