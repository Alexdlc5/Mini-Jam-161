using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 1.0f;
    public float offset = 0.0f;
    public float dead_zone = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        //calculate speed and move towards mouse
        float cursor_distance = Vector3.Distance(transform.position, mouse_position);
        float calculated_speed = speed * cursor_distance;
        if (cursor_distance > dead_zone)
        {
            //update mouse position
            mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get mouse distance and adjusts speed
            float mouse_distance = Vector2.Distance(mouse_position, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2)));
            float distance_multiplier = mouse_distance * speed;
            //move towards mouse
            transform.position = Vector2.MoveTowards(transform.position, mouse_position, distance_multiplier * Time.fixedDeltaTime);
            //get angle between mouse and object, rotate accordingly
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        }
    }
}
