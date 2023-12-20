using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_Sprite : MonoBehaviour
{
    //5s to do a full rotation (1s/hour)
    private const float REAL_SECONDS_PER_INGAME_DAY = 5f;
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private float day;

    private void Awake(){
        clockHourHandTransform = transform.Find("Big tick");
        clockMinuteHandTransform = transform.Find("Small tick");
    }

    private void Update(){
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        float dayNormalized = day % 1f;
        float rotationDegreesPerDay = 360f;
        clockHourHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay);
        float hoursPerDay = 24f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay*hoursPerDay);
    }
}
