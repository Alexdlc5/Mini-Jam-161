using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Wall_Check : MonoBehaviour
{

    public bool contact = false;
    private int points = 0;
    private void Update()
    {
        if (points == 0) { contact = false; }
        else { contact = true; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") 
        {
            points++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            points--;
        }
    }
}
