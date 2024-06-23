using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Customer_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public float midpoint_rotation = 90f;
    public float possible_rotation_range = 10f;
    public float bounce = 4f;
    public Customer_Wall_Check check;
    public Shelf_Stock_Monitor SSM;
    public GameObject next_c;
    public bool[] stages = { true, true, true };
    private void Start()
    {
        SSM = GameObject.FindGameObjectWithTag("SSM").GetComponent<Shelf_Stock_Monitor>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (SSM.timer >= 20 && stages[0] == true) { 
            speed += 50;
            stages[0] = false;
        }
        else if (SSM.timer >= 45 && stages[1] == true) { 
            speed += 50; 
            stages[1] = false;
        }
        else if (SSM.timer >= 60 && stages[2] == true) { 
            GameObject newcustomer = Instantiate(next_c);  
            stages[2] = false; 
        }
        //move forward
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;
        if (check.contact) rotate();
    }
    //rotate in random direction
    private void rotate()
    {
        float LorR = Random.Range(0,1);
        rb.velocity = transform.up * speed * -bounce * Time.fixedDeltaTime;
        float rotation = midpoint_rotation + Random.Range(-possible_rotation_range, possible_rotation_range);
        if (LorR > .5f) { transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, rotation)); }
        else { transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, -rotation)); }
    }

}
