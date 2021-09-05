using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EffectButton : MonoBehaviour, IPointerClickHandler
{

    bool sound = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        EffectManager.getInstance().ToggleEffect();
    }

    // Start is called before the first frame update
     public void BGMBtnColor()
    {
        if (sound == false)
        {
            GetComponent<Image>().color = new Color(1, 1, 1);
            sound = true;
        }
        else if (sound == true)
        {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            sound = false;
        }
    }
}
