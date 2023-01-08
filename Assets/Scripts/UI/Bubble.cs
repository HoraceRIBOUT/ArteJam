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
    public UnityEngine.UI.Image bubbleBg;
    public TMPro.TMP_Text textTMP;
    public RectTransform rect;

    public Vector2 minMaxSize = new Vector2(20, 180);

    public float pixelPerChar = 5f;

    public Vector3 targetPosition = Vector3.zero;

    [Button()]
    public void Create()
    {
        Create(textToDisplay, rect.sizeDelta.y, this.transform.position, new BubbleGenerator.colorPerPerso());
    }
    public void Create(string text, float height, Vector3 startPos, BubbleGenerator.colorPerPerso colPerPers)
    {
        textToDisplay = text;
        textTMP.SetText(text);
        textTMP.color = colPerPers.text;
        bubbleBg.color = colPerPers.bg;

        float sizeX = text.Length * pixelPerChar + minMaxSize.x;
        if (sizeX > minMaxSize.y)
            sizeX = minMaxSize.y;

        Debug.Log("sizeX = " + sizeX);

        rect.sizeDelta = new Vector2(sizeX, height);
        targetPosition = startPos;
    }

    public void SetTargetPos_Relative(Vector3 offset)
    {
        targetPosition += offset;
    }

    public void Update()
    {
        if(this.transform.position != targetPosition)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * 4f);
        }
    }


    public void End()
    {
        GameManager.instance.bubbleTextGen.pastBubble.Remove(this);
        Destroy(this.gameObject);
    }

}
