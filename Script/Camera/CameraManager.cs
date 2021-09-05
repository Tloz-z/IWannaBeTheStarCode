using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using TMPro;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public float moveSpeed = 10f;
    public Vector3 targetPosition;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject pause;

    public TextMeshProUGUI LogText;

    // Update is called once per frame
    void Update()   {


        if (target.transform.position.y >= 213)
        {
            transform.position = new Vector3(0, 210, 0);

            Social.ReportScore(GameObject.Find("ValueController").GetComponent<ValueController>().currentJumpCount, GPGSIds.leaderboard_jumpranking, (bool bsuccess) =>
            {
                if (bsuccess)
                {
                    LogText.text = "Score repot successful";
                }
                else
                {
                    LogText.text = "Score repot failed";
                }
            });
            Social.ReportScore((int)GameObject.Find("ValueController").GetComponent<ValueController>().currentPlayTime, GPGSIds.leaderboard_timeranking, (bool bsuccess) =>
            {
                if (bsuccess)
                {
                    LogText.text = "Score repot successful";
                }
                else
                {
                    LogText.text = "Score repot failed";
                }
            });
            pause.SetActive(false);
            panel.SetActive(true);
        }
        else
        {
            targetPosition.Set(this.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
