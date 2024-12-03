using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI text;     //conects to the text to show points earned
    public int coinAmount = 0;    //int or number that comes from coinAmount to do final score
    public HealthSystem HealthSystemScript;

    private bool isGamePaused = false; //variable to track if game is paused



    public void ShowGameOverScript()
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
        SceneManager.LoadScene("SceneThree");
    }

    public void ExitButton()
    {
        Time.timeScale = 1;   //Unpause the game
        SceneManager.LoadScene("SceneOne");
    }
}
