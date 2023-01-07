using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passageur : MonoBehaviour
{
    public List<GameObject> allCharacterToDisplay;

    public List<GameObject> allRemainingChar;

    public void Start()
    {
        StartGame();    
    }

    void StartGame()
    {
        GameManager.instance.ui_man.ResetTiming();
        allRemainingChar = new List<GameObject>(allCharacterToDisplay); //make a copy, and not a ref, to the list

        LaunchNextChar();
    }

    public void CharSuccess()
    {
        //called by character once there puzzle is resolved

        //T DO O
    }

    void LaunchNextChar()
    {
        int randomNumb = Random.Range(0, allRemainingChar.Count);

        GameObject selectedPrefabs = allRemainingChar[randomNumb];
        GameObject createdGO = Instantiate(selectedPrefabs);

        Character createdChar = createdGO.GetComponent<Character>();
        createdChar.Launch();

        allRemainingChar.RemoveAt(randomNumb);
    }
}
