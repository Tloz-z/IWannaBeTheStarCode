using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{

    private Image image;

    private bool isLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {

        if(isLoad)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.02f);
            if(image.color.a <= 0.01)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Load()
    {
        isLoad = true;
    }
}
