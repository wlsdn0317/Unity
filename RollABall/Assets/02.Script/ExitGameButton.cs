using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Button()
    {
        Invoke("exitgame", 1f);
    }
    private void exitgame()
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
