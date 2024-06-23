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


    // Update is called once per frame
    void FixedUpdate()
    {
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
