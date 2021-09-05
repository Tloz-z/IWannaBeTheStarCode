using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int playtime = GameObject.Find("Player").GetComponent<Player>().GetPlayTime();
        int hour = playtime / 3600;
        int min = (playtime % 3600) / 60;
        int sec = (playtime % 3600) % 60;

        text.text = $"Time : {((hour < 10) ? $"0{hour}" : $"{hour}")} : {((min < 10) ? $"0{min}" : $"{min}")} : {((sec < 10) ? $"0{sec}" : $"{sec}")}";

    }
}
