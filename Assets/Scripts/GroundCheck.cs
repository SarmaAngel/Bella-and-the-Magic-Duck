using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject Player;

    private void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.tag == "Ground" || collision.tag == "Platform")
        {
            Player.GetComponent<Movement2D>().isGrounded = true;
            Debug.Log(Player.GetComponent<Movement2D>().isGrounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Platform")
        {
            Player.GetComponent<Movement2D>().isGrounded = false;
        }
    }
}
