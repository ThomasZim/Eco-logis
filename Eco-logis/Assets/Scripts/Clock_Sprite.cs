using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_Sprite : MonoBehaviour
{
    //5s to do a full rotation (5s/hour)
    private const float REAL_SECONDS_PER_INGAME_DAY = 720f;
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private float offset = 480f;

    private void Awake(){
        clockHourHandTransform = transform.Find("Big tick");
        clockMinuteHandTransform = transform.Find("Small tick");
    }

    private void Update(){
        float nbr_sec = ((float)CoreMechanics.time+offset)/REAL_SECONDS_PER_INGAME_DAY;
        float dayNormalized = nbr_sec % 1f;
        //day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        float rotationDegreesPerDay = 360f;
        float hoursPerDay = 12f;
        clockHourHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay*hoursPerDay);
        clockMinuteHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay);
    }
}
