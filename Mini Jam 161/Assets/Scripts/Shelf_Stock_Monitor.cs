using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf_Stock_Monitor : MonoBehaviour
{
    public int stocked_shelves; //set manually in engine
    public float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (stocked_shelves == 0) {
            //GAME OVER, save time
        } 
        else
        {
            timer += Time.deltaTime;
        }
    }
}
