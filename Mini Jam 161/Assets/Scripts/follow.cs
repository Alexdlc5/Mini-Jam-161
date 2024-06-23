using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject object_to_follow;
    private void LateUpdate()
    {
        transform.position = object_to_follow.transform.position;
    }
}
