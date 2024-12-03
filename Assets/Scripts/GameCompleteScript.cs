using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleteScript : MonoBehaviour
{
    public TextMeshProUGUI text;     //conects to the text to show points earned
    //public HealthSystem HealthSystemScript;

    private bool isGamePaused = false; //variable to track if game is paused


    public void ShowGameCompleteScript()
    {
        if (!isGamePaused)  //checking if game is not already paused
        {
            Time.timeScale = 0;    //Pause the game
            isGamePaused = true;   //Update the game pasue state
        }
        this.gameObject.SetActive(true);

        text.text = ScoreCounter.coinAmount.ToString() + " Points";  //implements the number of points to game over text
    }

    public void RestartButton()
    {
        Time.timeScale = 1;   //Unpause the game
        SceneManager.LoadScene("SceneThree");    //loads to stated scene
    }

    public void ExitButton()
    {
        Time.timeScale = 1;   //Unpause the game
        SceneManager.LoadScene("SceneOne");      //loads to stated scene
    }
}

