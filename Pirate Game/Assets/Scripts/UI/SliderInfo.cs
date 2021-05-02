using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInfo : MonoBehaviour
{
    [SerializeField] Slider gameTimeSlider;
    [SerializeField] Slider spawnTimerSlider;
    [SerializeField] OptionsInformation Info;
    
    void Update()
    {
        Info.gameTime = gameTimeSlider.value;
        Info.SpawnTime = spawnTimerSlider.value;
    }
}
