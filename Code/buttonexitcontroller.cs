using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonexitcontroller : MonoBehaviour
{
    private void buttonExit()
    {
        SceneManager.LoadScene(0);
    }
}
