using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth()
    {
        slider.maxValue = 80;
        slider.minValue = 20;
        slider.value = CoreMechanics.getJoyScore();

        fill.color = gradient.Evaluate(1F);

    }
    public void SetHealth()
    {
        slider.value = CoreMechanics.getJoyScore();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
