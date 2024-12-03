using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    Text text;
    public static int coinAmount;
   
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = coinAmount.ToString();
    }

    public void ResetScore()
    {
        coinAmount = 0;
    }
}
