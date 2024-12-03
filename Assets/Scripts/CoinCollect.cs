using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Item item = collision.gameObject.GetComponent<Item>(); //get the Item component of the collided object

        if (item != null)  //check if the collided object hasan item component
        {
            ScoreCounter.coinAmount += item.value();   //if it colllides, increase score counter text by 1

            Destroy(collision.gameObject);  //once it collides destroy the collectable game object
        }
        
    }
}

//coinAmount += crayon.value();

//if (collision.gameObject.CompareTag("Collectables"))  //check if gameobject is colliding with an item tagged "Collectables"
//{
 //   ScoreCounter.coinAmount += 1;   //if it colllides, increase score counter text by 1
//    GameOverScript.coinAmount += 1;

  //  Destroy(collision.gameObject);  //once it collides destroy the collectable game object
//}