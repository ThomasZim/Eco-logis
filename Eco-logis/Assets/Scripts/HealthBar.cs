using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider.maxValue = 70;
        slider.minValue = 0;
        slider.value = (float)(CoreMechanics.getJoyScore());

       

    }
    void Update()
    { 
        slider.value = (float)(CoreMechanics.getJoyScore());
        
    }
}
