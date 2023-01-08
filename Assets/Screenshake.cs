using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{

    public void Shake()
    {
        GameManager.instance.postProcess.ScreenShake(0.2f);
    }

    public void Shake_Part(float value)
    {
        GameManager.instance.postProcess.ScreenShake(value);
    }
}
