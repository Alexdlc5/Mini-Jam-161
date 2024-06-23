using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Main_Menu_Manager : MonoBehaviour
{
    public TextMeshProUGUI prev;
    public TextMeshProUGUI best;
    // Start is called before the first frame update
    void Start()
    {
        prev.text = "Previous Time: " + Game_Data.previous_time;
        best.text = "Best Time: " + Game_Data.best_time;
    }
}
