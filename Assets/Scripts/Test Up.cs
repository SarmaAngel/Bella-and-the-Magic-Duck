using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUp : MonoBehaviour
{
    private Rigidbody2D rb;  // Declare a private variable to hold the Rigidbody2D component - NOI

    private bool isGravityUp;  // Declare a private boolean variable to track whether gravity is currently set to up - NOI

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get and assign the Rigidbody2D component of the GameObject this script is attached to - NOI
        isGravityUp = false; // Initialize the variable to indicate that gravity is initially not up - NOI
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))   // Check if the 'Space' key is pressed - NOI
        {
            ToggleGravity();  // Call the ToggleGravity method - NOI
        }
    }

    // Method to toggle between setting gravity up and restoring it to its original direction - NOI
    void ToggleGravity()
    {
        if (isGravityUp)
        {
            // Reset the gravity scale to its original value (1) to restore the original gravity direction  - NOI
            rb.gravityScale = 1f;

            // Reset the scale to make the GameObject's y-axis positive - NOI
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // Set the gravity scale to -1 to make gravity act upwards - NOI
            rb.gravityScale = -1f;

            // Flip the scale on the y-axis to -1 to invert the GameObject - NOI
            transform.localScale = new Vector3(1, -1, 1);
        }

        // Invert the value of 'isGravityUp' for the next toggle - NOI
        isGravityUp = !isGravityUp;
    }
}
