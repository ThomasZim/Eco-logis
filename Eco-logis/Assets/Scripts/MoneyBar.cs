using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
     public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int money)
    {
        slider.maxValue = money;
        slider.value = money;

        fill.color = gradient.Evaluate(1F);

    }
    public void SetHealth(int money)
    {
        slider.value = money;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
