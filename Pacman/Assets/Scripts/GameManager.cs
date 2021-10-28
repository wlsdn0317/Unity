using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score;
    public Text point;
    public GameObject gameoverPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        
    }

    void Update()
    {
        point.text = score.ToString();
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
        gameoverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
