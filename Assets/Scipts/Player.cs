using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isReturn;
    public Vector3 originPos;


    public Player()
    {

        isReturn = false;
       
        
    }
    private void Start()
    {
        originPos = transform.position;
    }
    private void Update()
    {
        isReturn = isReturned();
        
    }

    private bool isReturned() {

        if (transform.position == originPos) {
            return true;
        }

        return false;
    }


    public bool Move(Vector2 direction) {

        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else {
            direction.y = 0;
        }
        direction.Normalize(); // either x ot y  = 1

        if (isBlocked(transform.position, direction))
        {
            return false;
        }
        else {
         
            transform.Translate(direction);
            return true;
        }
    }
    public bool isBlocked(Vector3 pos, Vector2 direction) {

        Vector2 newPos = new Vector2(pos.x, pos.y) + direction;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls) {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y) {
                return true;

            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes) {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y) {

                Box bx = box.GetComponent<Box>();

                if (bx && bx.Move(pos,direction))
                {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        return false;

    }
    
}
