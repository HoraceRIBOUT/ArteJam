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
    public bool stopDecreasing = false;
    public Animator gameOverAnima;
    public Animator victoryAnima;
    public Animator timingAnimator;


    Coroutine fillUp_CoRout = null;

    public void Update()
    {
        /*
        if (!GameManager.instance.passageur.isActiveAndEnabled)
            return;*/
        if (GameManager.instance.isIntro)
            return;
        if (GameManager.instance.isGameOver)
            return;
        if (stopDecreasing)
            return;


        if (timing.value == 1)
        {
            timingAnimator.enabled = false;
        }

        timing.value -= Time.deltaTime / timerDuration;


        if (timing.value <= 0)
        {
            //Game over
            GameManager.instance.GameOver();
            timing.value = 0;
        }
    }

    public void Success()
    {
        fillUp_CoRout = StartCoroutine(FillUpPatience());
    }


    public IEnumerator FillUpPatience()
    {
        stopDecreasing = true;
        yield return new WaitForSeconds(0.3f);

        while(timing.value < 1)
        {
            timing.value += Time.deltaTime * 2f;
            yield return new WaitForSeconds(1f / 60f);
        }
        fillUp_CoRout = null;
    }

    public void ResetTiming()
    {
        if (fillUp_CoRout != null)
            StopCoroutine(fillUp_CoRout);

        timing.value = 1f;
        stopDecreasing = false;
    }

    public void GameOver()
    {
        gameOverAnima.SetTrigger("GameOver");
    }

    public void Victory()
    {
        victoryAnima.SetTrigger("Victory");
        GameManager.instance.isVictory = true;
        GameManager.instance.PrepareForReload(5f);
    }
}
