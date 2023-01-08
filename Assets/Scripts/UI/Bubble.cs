using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Bubble : MonoBehaviour
{
    [Header("Text")]
    [TextArea]
    public string textToDisplay;

    [Header("For code")]
    public TMPro.TMP_Text textTMP;
    public RectTransform rect;

    public Vector2 minMaxSize = new Vector2(20, 180);

    public float pixelPerChar = 5f;

    [Button()]
    public void Create()
    {
        Create(textToDisplay);
    }
    public void Create(string text)
    {
        textToDisplay = text;
        textTMP.SetText(text);

        float sizeX = text.Length * pixelPerChar + minMaxSize.x;
        if (sizeX > minMaxSize.y)
            sizeX = minMaxSize.y;

        Debug.Log("sizeX = " + sizeX);

        rect.sizeDelta = new Vector2(sizeX, rect.sizeDelta.y);
    }

}
