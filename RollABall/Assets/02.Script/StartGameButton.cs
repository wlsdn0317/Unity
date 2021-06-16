using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Button()
    {
        Invoke("startgame", 1f);
    }
    private void startgame()
    {
        SceneManager.LoadScene("1stage");
    }

}
