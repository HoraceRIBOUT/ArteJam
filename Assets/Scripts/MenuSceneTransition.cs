using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneTransition : MonoBehaviour
{

    [SerializeField] GameObject menuBase;
    [SerializeField] GameObject menuCredit;

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void GameScene()
    {
        SceneManager.LoadScene(1);
        
    }
    public void SwitchBaseToCredit()
    {
        menuBase.SetActive(!menuBase.activeSelf);
        menuCredit.SetActive(!menuCredit.activeSelf);
    }


}
