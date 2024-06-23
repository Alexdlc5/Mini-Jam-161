using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public bool stocked = true;
    private SpriteRenderer spriteRenderer;
    public Shelf_Stock_Monitor shelfManager;
    public GameObject pickup_SFX;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(.5f, 1f, .5f, .5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Player_Data>().items_held > 0 && stocked == false)
        {
            Player_Data playerData = collision.gameObject.GetComponent<Player_Data>();
            playerData.items_held--;
            playerData.updateIcons();
            shelfManager.stocked_shelves++;
            stocked = true;
            //set color green
            spriteRenderer.color = new Color(.5f, 1f, .5f, .5f);
        }
        else if (collision.tag == "Customer" && stocked == true)
        {
            Instantiate(pickup_SFX);
            int c_items_needed = collision.gameObject.GetComponent<Customer_Data>().items_needed;
            if (c_items_needed == 0) { } //customer flys out the fucking window (poof away 4 now)
            else { c_items_needed--; }
            shelfManager.stocked_shelves--;
            stocked = false;
            //set color grey
            spriteRenderer.color = new Color(.5f, .5f, .5f, .5f);
        }
    }
}
