using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Shelf_Stock_Monitor : MonoBehaviour
{
    public TextMeshProUGUI timer_text;
    public int stocked_shelves; //set manually in engine
    public float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (stocked_shelves == 0) {
            //GAME OVER
            float truncated_time = timer - (timer % .01f);
            Game_Data.previous_time = truncated_time;
            if (timer > Game_Data.best_time) 
            {
                Game_Data.best_time = truncated_time;
            }
            //loads gameover scene \/-- make sure that is correct scene index
            SceneManager.LoadScene(2);
        } 
        else
        {
            timer += Time.deltaTime;
        }
        timer_text.text = "TIME: " + timer;
    }
}
