using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneTransition : MonoBehaviour
{

    [SerializeField] GameObject menuBase;
    [SerializeField] GameObject menuCredit;

    [SerializeField] Animator animator;

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void SwitchBaseToCredit()
    {
        menuBase.SetActive(!menuBase.activeSelf);
        menuCredit.SetActive(!menuCredit.activeSelf);
    }

    public void StartSwitchScene()
    {
        StartCoroutine(GameScene());
    }

    public IEnumerator GameScene()
    {
        menuBase.SetActive(!menuBase.activeSelf);
        animator.SetBool("canPlay", true);

        yield return new WaitForSeconds(AudioManager.instance.fadeTime);

        //StopCoroutine(AudioManager.instance.FadeOutMusicMenu);
        //StopCoroutine(AudioManager.instance.FadeInMusicGame);
        //StopCoroutine(AudioManager.instance.FadeOutPeopleEntry);

        SceneManager.LoadScene(1);
    }

}
