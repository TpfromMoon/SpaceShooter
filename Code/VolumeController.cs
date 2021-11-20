using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider BGMSlider;
    public AudioSource BGMSource;

    public void VolumeChange()
    {
        BGMSource.volume = BGMSlider.value;
        
        
    }
    
   
    
}
