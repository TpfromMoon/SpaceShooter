using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    //转场效果


    

    public void playgame()
    {
       ScreenFaderInout.fadeIn = true;
        Time.timeScale = 1;
    }
    public void exitgame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
