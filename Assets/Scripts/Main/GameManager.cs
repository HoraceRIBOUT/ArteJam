using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Passageur passageur;
    public UI_Manager ui_man;
    public PostProcess postProcess;

    public bool isGameOver = false;
    public bool isVictory = false;

    public void GameOver()
    {
        isGameOver = true;
        ui_man.GameOver();
        postProcess.intensity = 1f;

        PrepareForReload(1.5f);
    }

    public void PrepareForReload(float waitTime)
    {
        StartCoroutine(WaitForClick(waitTime));
    }

    public IEnumerator WaitForClick(float waitTime)
    {
        bool someoneclicked = false;
        yield return new WaitForSeconds(waitTime);//for the ui to display
        while (!someoneclicked)
        {
            someoneclicked = Input.GetMouseButtonDown(0);
            yield return new WaitForSeconds(1f / 100f);
        }

        SceneManager.LoadScene(0);
    }
}
