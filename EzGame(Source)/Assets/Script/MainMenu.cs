using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public static int difficultLevel = 0;
    private void Update()
    {
        
       
    }
    public void Easy()
    {
        difficultLevel = 1;
        SceneManager.LoadScene("Stage1");
        Time.timeScale = 1;
    }
    public void Medium()
    {
        difficultLevel = 2;
        SceneManager.LoadScene("Stage1");
        Time.timeScale = 1;
    }
    public void Hard()
    {
        difficultLevel = 3;
        SceneManager.LoadScene("Stage1");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
