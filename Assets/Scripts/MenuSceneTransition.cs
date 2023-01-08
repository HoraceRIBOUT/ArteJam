using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneTransition : MonoBehaviour
{

    [SerializeField] GameObject menuBase;
    [SerializeField] CanvasGroup menuBase_Canvas;
    [SerializeField] GameObject menuCredit;
    [SerializeField] GameObject title;
    [SerializeField] UnityEngine.UI.Image title_Sprite;
    [SerializeField] GameObject sprMiror;

    [SerializeField] Animator animator;

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void SwitchBaseToCredit()
    {
        menuBase.SetActive(!menuBase.activeSelf);
        menuCredit.SetActive(!menuCredit.activeSelf);
        title.SetActive(!title.activeSelf);
        sprMiror.SetActive(!sprMiror.activeSelf);
    }

    public void StartSwitchScene()
    {
        StartCoroutine(GameScene());
        StartCoroutine(ButtonFade());
    }

    public IEnumerator GameScene()
    {
        animator.SetBool("canPlay", true);

        yield return new WaitForSeconds(AudioManager.instance.fadeTime);

        //StopCoroutine(AudioManager.instance.FadeOutMusicMenu);
        //StopCoroutine(AudioManager.instance.FadeInMusicGame);
        //StopCoroutine(AudioManager.instance.FadeOutPeopleEntry);

        SceneManager.LoadScene(1);
    }
    public IEnumerator ButtonFade()
    {
        menuBase_Canvas.interactable = false;

        while (menuBase_Canvas.alpha > 0)
        {
            menuBase_Canvas.alpha -= Time.deltaTime * 4f;
            title_Sprite.color -= Color.black * Time.deltaTime * 4f;
                yield return null;
        }
    }

}
