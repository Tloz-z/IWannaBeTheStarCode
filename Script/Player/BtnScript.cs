using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnScript : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private float[] AddFoce;

    [SerializeField]
    private float[] minClickTime;

    private bool isClick;
    private float clickTime;    

    public enum Pointer
    {
        LEFT,
        RIGHT
    }

    public Pointer pointer;


    void Update()
    {
       
        if (isClick)
        {
            clickTime += Time.deltaTime;
        }
        else
        {
            clickTime = 0;
        }        
    }

    public void ButtonUpLeft()
    {
            isClick = false;

        if (GameObject.Find("Player").GetComponent<Player>().canJump || GameObject.Find("Player").GetComponent<Player>().isStop)
        {
            print(clickTime);




            if ((clickTime >= minClickTime[3]))
            {
                rigid.AddForce(Vector2.up * AddFoce[3] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.left * AddFoce[3], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().Jump(1);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);

            }
            else if ((clickTime >= minClickTime[2]))
            {
                rigid.AddForce(Vector2.up * AddFoce[2] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.left * AddFoce[2], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().Jump(1);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);


            }

            else if ((clickTime >= minClickTime[1]))
            {
                rigid.AddForce(Vector2.up * AddFoce[1] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.left * AddFoce[1], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().Jump(1);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);


            }

            else if (clickTime >= minClickTime[0])
            {
                rigid.AddForce(Vector2.up * AddFoce[0] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.left * AddFoce[0], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);

            }


        }
    }


    public void ButtonUpRight()
    {
            isClick = false;
        if (GameObject.Find("Player").GetComponent<Player>().canJump || GameObject.Find("Player").GetComponent<Player>().isStop)
        {
            print(clickTime);


            if ((clickTime >= minClickTime[3]))
            {
                rigid.AddForce(Vector2.up * AddFoce[3] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.right * AddFoce[3], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().Jump(-1);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);


            }
            else if ((clickTime >= minClickTime[2]))
            {
                rigid.AddForce(Vector2.up * AddFoce[2] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.right * AddFoce[2], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().Jump(-1);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);

            }

            else if ((clickTime >= minClickTime[1]))
            {
                rigid.AddForce(Vector2.up * AddFoce[1] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.right * AddFoce[1], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().Jump(-1);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);

            }

            else if (clickTime >= minClickTime[0])
            {
                rigid.AddForce(Vector2.up * AddFoce[0] * 2, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.right * AddFoce[0], ForceMode2D.Impulse);
                GameObject.Find("Player").GetComponent<Player>().SetStartPos();
                EffectManager.getInstance().PlaySound(EffectManager.getInstance().jump);

            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    { 
        if(GameObject.Find("Player").GetComponent<Player>().isGameClear)
        {
            return;
        }

        if(pointer == Pointer.LEFT)
        {
            ButtonUpLeft();
        } else
        {
            ButtonUpRight();
        }
    }
}
