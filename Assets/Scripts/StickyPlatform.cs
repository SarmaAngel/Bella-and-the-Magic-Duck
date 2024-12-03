using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This method is called when a 2D collision occurs.

        if (collision.gameObject.name == "Player")     // Check if the GameObject involved in the collision has the name "Player."
        {
            collision.gameObject.transform.SetParent(transform);   // If it's the player, set the player's parent to this StickyPlatform (making it stick to the platform).
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // This method is called when the collision between the objects ends.

        if (collision.gameObject.name == "Player")     // Check if the GameObject involved in the collision has the name "Player."
        {

            collision.gameObject.transform.SetParent(null);       // If it's the player, remove the parent (unstick the player from the platform).

        }
    }
}

