using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //All zone to click on
    //  and how do it react to it ?
    //      either textBubble or anim or both


    public float timingBeforeDestoy = 2f;
    public float offSetY;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, offSetY, transform.position.z);
    }

    public void Launch()
    {
        //Do the introduction animation and the rest it need to do
    }


    public void GetOut()
    {
        if (gameObject.CompareTag("Muscle"))
        {
            AudioManager.instance.PlaySound("MuscleEclate");
            AudioManager.instance.PlaySound("MuscleOut");
        }
        if (gameObject.CompareTag("Calvitie"))
        {
            AudioManager.instance.PlaySound("CalvitieWind");
            //StartCoroutine(playSound());
        }
        if (gameObject.CompareTag("PixelArt"))
        {
            AudioManager.instance.PlaySound("JvHurt");
            AudioManager.instance.PlaySound("JvMort");
        }
        StartCoroutine(DestroyLater());
    }

    /*
    public IEnumerator playSound()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlaySound("CalvitieSors");
    }
    */
    public IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(timingBeforeDestoy);
        GameManager.instance.passageur.CharSuccess();
        Destroy(this.gameObject);
    }
}
