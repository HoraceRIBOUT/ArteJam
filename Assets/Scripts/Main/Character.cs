using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //All zone to click on
    //  and how do it react to it ?
    //      either textBubble or anim or both


    public float timingBeforeDestoy = 2f;

    public void Launch()
    {
        //Do the introduction animation and the rest it need to do
    }


    public void GetOut()
    {
        GameManager.instance.passageur.CharSuccess();

        StartCoroutine(DestroyLater());
    }

    public IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(timingBeforeDestoy);
    }
}
