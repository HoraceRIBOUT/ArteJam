using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_SuccessByAnim : MonoBehaviour
{
    public Character parentChar;
    public void Succeed()
    {
        GameManager.instance.ui_man.Success();

        if (parentChar == null)
        {
            parentChar = GetComponentInParent<Character>();
        }

        //can add a little timer for text and anim
        parentChar.GetOut();
    }
}
