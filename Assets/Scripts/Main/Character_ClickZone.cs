using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Character_ClickZone : MonoBehaviour
{
    bool canClickOnIt = true;
    public float howLongToWaitBetweenClick = .3f;

    //Success : yes no ?
    public bool success;

    //Launch a bubble ?
    public bool bubbleText = false;
    [ShowIf("bubbleText")] public List<string> textToDisplay;
    //Launch an anim' ?
    public bool playAnim = false;
    [ShowIf("playAnim")] public Animator anima;
    [ShowIf("playAnim")] public string triggerName = "";
    [ShowIf("playAnim")] public Animator parentAnima;
    [ShowIf("playAnim")] public string parentTriggerName = "";


    public Character parentChar;

    public void OnMouseDown()
    {
        Debug.Log("Click on " + this.name);

        if (!canClickOnIt)
            return;

        if (bubbleText)
        {
            //TO DO
        }

        if (playAnim)
        {
            if(triggerName != "")
            {
                anima.SetTrigger(triggerName);
            }
            if(parentTriggerName != "")
            {
                parentAnima.SetTrigger(parentTriggerName);
            }
        }

        if (success)
        {
            if(parentChar == null)
            {
                parentChar = GetComponentInParent<Character>();
            }
            
            //can add a little timer for text and anim
            parentChar.GetOut(); 
        }

        canClickOnIt = false;
        StartCoroutine(TimerBeforeClickAgain());
    }

    public IEnumerator TimerBeforeClickAgain()
    {
        yield return new WaitForSeconds(howLongToWaitBetweenClick);
        canClickOnIt = true;
    }
}
