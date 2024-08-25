using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window_Date : MonoBehaviour
{

    public void Window_Control(string Scene_String)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene_String);
    }
    
}
