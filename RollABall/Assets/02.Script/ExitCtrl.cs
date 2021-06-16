using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCtrl : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameQuit();
        }
    }
    void GameQuit()
    {
        #if (UNITY_EDITOR)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
        {
                Application.Quit();
        }
        #endif
    }
}
