using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Slider Health_Slider;
    public Gradient gradient;
    public Image Fill;

    public void SetMaxHealth(int health)
    {
        Health_Slider.maxValue = health;
        Health_Slider.value = health;
        Fill.color = gradient.Evaluate(1f);
        
    }
    public void SetHealth(int health)
    {
        Health_Slider.value = health;
        Fill.color = gradient.Evaluate(Health_Slider.normalizedValue);
    }

}
