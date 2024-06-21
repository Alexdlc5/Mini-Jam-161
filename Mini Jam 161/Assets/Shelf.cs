using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public bool stocked = false;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(.5f, 1f, .5f, .5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Player_Data>().holding_item == true)
        {
            stocked = true;
            //set color green
            spriteRenderer.color = new Color(.5f, 1f, .5f, .5f);
        }
        else if (collision.tag == "Customer")
        {
            int c_items_needed = collision.gameObject.GetComponent<Customer_Data>().items_needed;
            if (c_items_needed == 0) { } //fly out the fucking window (poof away 4 now)
            else { c_items_needed--; }
            stocked = false;
            //set color grey
            spriteRenderer.color = new Color(.5f, .5f, .5f, .5f);
        }
    }
}
