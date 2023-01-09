using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    public float intensity = 0.04f;

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.postProcess.fishEye = intensity;
    }
}
