using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Balancing")]
    public float timerDuration = 10;


    [Header("Prog part")]
    public Slider timing;



    public void Update()
    {
        timing.value -= Time.deltaTime / timerDuration;


        if (timing.value < 0)
        {
            //Game over
            timing.value = 0;
        }
    }

    public void ResetTiming()
    {
        timing.value = 1f;
    }
}
