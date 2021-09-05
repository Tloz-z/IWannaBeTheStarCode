using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEx : MonoBehaviour
{
    [SerializeField]
    private float angleSpeed = 1000f;

    public bool isJump = false;

    private float signedAngle;
    private bool isCollisionDelay = false;

    private float collisionDelayAmount = 0.1f;

    private float tick = 0;

    [SerializeField]
    private GameObject Wall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 180)
        {
            gameObject.GetComponent<PlayerEx>().enabled = false;
            gameObject.GetComponent<EndingScript>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            Destroy(Wall);
        }

        if (isJump)
        {
            tick += Time.deltaTime;
            if(tick > collisionDelayAmount)
            {
                isCollisionDelay = true;
            }
            transform.Rotate(Vector3.forward * signedAngle * Time.deltaTime * angleSpeed);
        }
    }


    public void Jump(int side)
    {
        signedAngle = side;
        isJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isCollisionDelay)
        {
            isJump = false;
            isCollisionDelay = false;
            tick = 0f;
        }
    }
}
