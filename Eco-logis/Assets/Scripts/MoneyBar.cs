using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
     public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider.maxValue = 25000;
        slider.minValue = 0;
        slider.value = (float)(CoreMechanics.money);

     

    }
    void Update()
    {
        slider.value = (float)(CoreMechanics.money);
    }
}
