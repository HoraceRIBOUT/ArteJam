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

    public List<string> textToDisplay_intro;

    public BubbleGenerator.who who;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, offSetY, transform.position.z);

        StartCoroutine(Dialogue(textToDisplay_intro));
    }


    public IEnumerator Dialogue(List<string> textsToDisplay)
    {
        foreach (string textToDisplay in textsToDisplay)
        {
            GameManager.instance.bubbleTextGen.AddBubble(textToDisplay, BubbleGenerator.who.mirror);
            yield return new WaitForSeconds(0.3f);
        }
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
