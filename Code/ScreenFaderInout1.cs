using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScreenFaderInout1 : MonoBehaviour
{
    public Texture image;
    static float fade1 = 0f;
    public static bool fadeIn1 = false;
    public static bool fadeOut1 = false;
    public void OnGUI()
    {
        if (fadeIn1)
        {
            fade1 += 0.5f * Time.deltaTime;
            if (fade1 >= 1f)
            {
                fadeIn1 = false;
                SceneManager.LoadScene(0);
                
                fadeOut1 = true;

            }
        }
        if (fadeOut1)
        {
            fade1 -= 0.5f * Time.deltaTime;
            if (fade1 <= 0)
            {
                fadeOut1 = false;
            }
        }
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, fade1);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
