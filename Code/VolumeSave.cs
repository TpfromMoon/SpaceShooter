using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeSave : MonoBehaviour
{
    public GameObject VolumeObject;
    private void Awake()
    {
        DontDestroyOnLoad(VolumeObject);
        SceneManager.LoadScene("spaceshooter");
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
