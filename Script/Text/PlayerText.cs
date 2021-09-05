using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour
{
    private const float SHOW_TEXT_LIMIT = 3.0f;

    private TextMeshPro textbox;

    private bool isShowText = false;
    private float showTextTick = 0f;

    void Start()
    {
        textbox = GetComponent<TextMeshPro>();
        textbox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position + new Vector3(0f, 1.2f, 0f);

        if (isShowText)
        {
            showTextTick += Time.deltaTime;
            if (showTextTick > SHOW_TEXT_LIMIT)
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
