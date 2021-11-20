using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScreenFaderInout : MonoBehaviour
{
    public Texture image;
    static float fade = 0f;
    public static bool fadeIn = false;
    public static bool fadeOut = false;
    public void OnGUI()
    {
        if (fadeIn)
        {
            fade += 0.5f * Time.deltaTime;
            if(fade>=1f)
            {
                SceneManager.LoadScene(1);
                fadeIn = false;
                fadeOut= true;

            }
        }
        if(fadeOut)
        {
            fade -= 0.5f * Time.deltaTime;
            if(fade<=0f)
            {
                fadeOut = false;
            }
        }
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, fade);
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
