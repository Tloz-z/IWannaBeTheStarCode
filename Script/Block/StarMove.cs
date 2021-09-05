using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{    
    Vector3 pos; //현재위치
    public float delta;
    public float speed;
    public float pok;

    void Start()
    {

        pos = transform.position;

    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);

        Vector3 v = pos;

        v.y += delta * Mathf.Cos(Time.time * pok);

        transform.position = v;
    }
}
