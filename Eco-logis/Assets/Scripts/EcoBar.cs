using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcoBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = (float)(CoreMechanics.getEcologyScore());

     

    }
    void Update()
    {
        slider.value = (float)(CoreMechanics.getEcologyScore());
        
    }
}
