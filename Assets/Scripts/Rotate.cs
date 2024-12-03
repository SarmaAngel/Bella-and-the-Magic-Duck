using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;  //variable to control rotation speed

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); //rotayes 360 every 2 seconds in delta time
    }
}
