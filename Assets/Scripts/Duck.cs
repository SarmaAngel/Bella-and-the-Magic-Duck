using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public GameCompleteScript gameCompleteScript;   //has accsees to this script

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Duck"))  //check if gameobject is colliding with an item tagged "Collectables"
        {
                if (gameCompleteScript != null)
                 {
                    PauseGame(); //call method to pause the game
                    gameCompleteScript.ShowGameCompleteScript(); //calling gameoverscript method to be played
                 }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;  //set time scale to 0 to pause game
        
    }
}   
