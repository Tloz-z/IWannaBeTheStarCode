using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{    
    Vector3 pos; //현재위치

    public float delta;
    public float speed;

    void Start()
    {

        pos = transform.position;

    }


    void FixedUpdate()
    {

        Vector3 v = pos;

        v.y += delta * Mathf.Sin(GameObject.Find("Player").GetComponent<Player>().playtime * speed);        

        transform.position = v;

    }
}
