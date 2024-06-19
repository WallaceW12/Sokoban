using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMessage : MonoBehaviour
{
    static GameObject win;
    static bool visible;

    // Start is called before the first frame update

    private void Start()
    {
        win = GameObject.Find("CanvasWinMessage");
        win.SetActive(true);

        win = GameObject.Find("Win");
        win.SetActive(false);
    }
    public static void isVisible() {

       win.SetActive(true);
    }
    public static void notVisible() {

        win.SetActive(false);
    }
}
