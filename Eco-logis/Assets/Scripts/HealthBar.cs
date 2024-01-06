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
        slider.maxValue = 100;
        slider.minValue = 33;
        slider.value = (float)(CoreMechanics.GetJoyScore());

       

    }
    void Update()
    { 
        slider.value = (float)(CoreMechanics.GetJoyScore());
        
    }
}
