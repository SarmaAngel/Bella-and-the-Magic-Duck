using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public Movement2D movement;

    private Rigidbody2D rb; //
    private float gravityTime = 2f;     //duration for gravity
    private Animator anim;     //reference to animator comp

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //allowing shortcut of using rb
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(IEGravity());
            movement.isFloating = true;
        }

        if (rb.gravityScale > 0)
        {
            movement.isFloating = false;
        }
    }

    public IEnumerator IEGravity()
    {
        if (Input.GetKeyDown(KeyCode.U))    //setting the gravity change button to U
        {
            rb.gravityScale *= -1;          //gravity scale now multiplied by -1, making gravity now up
        }


        yield return new WaitForSeconds(gravityTime);

        if (rb.gravityScale < 0)
        {
            rb.gravityScale *= -1;
        }

        movement.isFloating = false;

    }

}
