using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Date : MonoBehaviour
{
    bool pauseOpened = false;
    public GameObject Window_Object;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PauseGame(!pauseOpened);

            
           
            //string Str = Boal ? "Game_Start_Window" : "SampleScene";
            ////Window_Object.GetComponent<Window_Date>().Window_Control("Game_Start_Window");
        }
    }

    public void PauseGame(bool open)
    {
        Time.timeScale = open ? 0 : 1;
        pauseOpened = open;
        Window_Object.SetActive(open);
    }

}
//Time.timeScale = Number != 1 ? Number = 0 : Number = 1
//SampleScene