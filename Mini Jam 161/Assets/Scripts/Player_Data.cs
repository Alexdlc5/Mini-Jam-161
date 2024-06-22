using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data : MonoBehaviour
{
    public int items_held = 0;
    public GameObject[] held_item_icons;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Storage")
        {
            items_held = 3;
            for (int i = 0; i < held_item_icons.Length; i++)
            {
                held_item_icons[i].GetComponent<Renderer>().enabled = true;
            }
        }
    }
    public void updateIcons()
    {
        //all icons disabled
        for (int i = 0; i < held_item_icons.Length; i++)
        {
            held_item_icons[i].GetComponent<Renderer>().enabled = false;
        }
        //neccessary icons enabled
        for (int i = 0; i < items_held; i++)
        {
            held_item_icons[i].GetComponent<Renderer>().enabled = true;
        }
    }
}
