using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWall : MonoBehaviour

{
    public SpriteRenderer render;
    
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().isJump == true)
        {
            render.color = new Color(0, 0, 0, 1);
        }
        else if (GameObject.Find("Player").GetComponent<Player>().isJump == false)
        {
            render.color = new Color(1, 1, 1, 0);
        }

    }
}
