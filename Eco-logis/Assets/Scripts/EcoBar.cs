using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcoBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int eco)
    {
        slider.maxValue = eco;
        slider.value = eco;

        fill.color = gradient.Evaluate(1F);

    }
    public void SetHealth(int eco)
    {
        slider.value = eco;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
