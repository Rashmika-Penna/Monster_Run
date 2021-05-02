using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill_health;

    public void Set_Max_Health(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill_health.color = gradient.Evaluate(1f);
    }

    public void Set_Health(int health)
    {
        slider.value = health;
        fill_health.color = gradient.Evaluate(slider.normalizedValue);
    }
}

