using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialend : MonoBehaviour
{
    public GameObject tut;

    public void EndTutorial()
    {
        tut.SetActive(false);
        Time.timeScale = 1;
        BGMManager.getInstance().PlaySound(BGMManager.getInstance().defaultBGM);
    }
}
