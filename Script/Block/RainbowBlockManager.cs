using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBlockManager : MonoBehaviour
{

    public List<GameObject> red = new List<GameObject>();
    public List<GameObject> orange = new List<GameObject>();
    public List<GameObject> yellow = new List<GameObject>();
    public List<GameObject> green = new List<GameObject>();
    public List<GameObject> blue = new List<GameObject>();
    public List<GameObject> nam = new List<GameObject>();
    public List<GameObject> pupple = new List<GameObject>();

    private List<GameObject> allColorBlock = new List<GameObject>();


    public enum Color
    {
        RED,
        ORANGE,
        YELLOW,
        GRREN,
        BLUE,
        NAM,
        PUPPLE
    }

    private List<GameObject> GetColorBlockList(Color color)
    {
        switch(color)
        {
            case Color.RED:
                return this.red;
            case Color.ORANGE:
                return this.orange;
            case Color.YELLOW:
                return this.yellow;
            case Color.GRREN:
                return this.green;
            case Color.BLUE:
                return this.blue;
            case Color.NAM:
                return this.nam;
            case Color.PUPPLE:
                return this.pupple;
            default:
                return null;
        }
    }




    void Start()
    {
        allColorBlock.AddRange(red);
        allColorBlock.AddRange(orange);
        allColorBlock.AddRange(yellow);
        allColorBlock.AddRange(green);
        allColorBlock.AddRange(blue);
        allColorBlock.AddRange(nam);
        allColorBlock.AddRange(pupple);
    }

    public void LoadCollider(int color)
    {
        SetCollider((Color)color);
    }

    public void SetCollider(Color color)
    {
        GameObject.Find("Player").GetComponent<Player>().rainbowBlock = (int)color;

        List<GameObject> enableBlock = new List<GameObject>();

        List<GameObject> disableBlock = new List<GameObject>();
        disableBlock.AddRange(allColorBlock);

        foreach (var block in GetColorBlockList(color))
        {
            disableBlock.Remove(block);
        }

        if (color == Color.PUPPLE)
        {
            enableBlock.AddRange(GetColorBlockList(Color.RED));
        } else
        {
            enableBlock.AddRange(GetColorBlockList(color + 1));
        }

        foreach(var block in disableBlock)
        {
            block.GetComponent<Collider2D>().enabled = false;
        }

        foreach(var block in enableBlock)
        {
            block.GetComponent<Collider2D>().enabled = true;
        }
    }
}
