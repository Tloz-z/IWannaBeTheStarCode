using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private const float SHOW_TEXT_LIMIT = 3.0f;

    private Text textbox;

    private bool isShowText = false;
    private float showTextTick = 0f;

    void Start()
    {
        textbox = GetComponent<Text>();
        textbox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(isShowText)
        {
            showTextTick += Time.deltaTime;
            if(showTextTick > SHOW_TEXT_LIMIT)
            {
                textbox.text = "";
                isShowText = false;
            }
        }
    }

    public void BroadcastText(string text)
    {
        textbox.text = text;
        showTextTick = 0f;
        isShowText = true;
    }
}
