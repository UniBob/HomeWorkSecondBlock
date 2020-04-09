using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    float minX = -6.4f;             //far left position of platform 
    float maxX = 6.4f;              //far right position of platform
    float x = 0;
    float y = -14;
    float z = 0;

    GameLogic gl;
    bool isPaused = false;

    void Start()
    {
        gl = FindObjectOfType<GameLogic>();
        transform.position = new Vector3(x,y,0);
    }

    void Update()
    {
        MoveWithMouse();
    }

    void MoveWithMouse()
    {
        if (isPaused)
        {
            //if game is paused platfaorm not moving   
        }
        else
        {
            //moving the platform by mouse if game isn't pause
            Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Clamp(tmp.x, minX, maxX), y, z);
        }
    }

    public void PauseButton()
    {
        isPaused = true;
    }

}
