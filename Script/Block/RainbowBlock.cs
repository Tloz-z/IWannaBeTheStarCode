using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBlock : MonoBehaviour
{
    public RainbowBlockManager.Color color = RainbowBlockManager.Color.RED;

    private bool isChange = false;
    private float tick = 0f;

    private void Update()
    {
        if (isChange)
        {
            tick += Time.deltaTime;
            if(tick >  0.3)
            {
                GameObject.Find("RainbowManager").GetComponent<RainbowBlockManager>().SetCollider(this.color);
                isChange = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Player"))
        {
            Debug.Log("Enter");

            tick = 0f;
            isChange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            tick = 0f;
            isChange = false;
        }
    }
}
