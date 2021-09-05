using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ValueController : MonoBehaviour
{

    private static ValueController instance;

    public bool isGameStart = false;
    public bool isLoad = false;

    public Vector3 currentPosition;
    public Vector3 currentVelocity;
    public Quaternion currentRotate;
    public float currentAngleVelocity;
    public float currentSignedAngle;
    public bool currentIsJump;
    public float currentPlayTime;
    public int currentJumpCount;
    public float currentStartPos;
    public float currentAngleSpeed;
    public int currentStage;
    public float currentMass;

    //레인보우
    public int currentRainbowBlock;

    //썬셋
    public Vector3 currentPlatformPosition0;
    public Vector3 currentPlatformPosition1;
    public Vector3 currentPlatformPosition2;

    //나이트 스카이
    public Vector3 currentPlatformNight;

    public static ValueController getInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        SaveSystem.SaveValue(this);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/value.fun";
        if (File.Exists(path))
        {
            this.isLoad = true;

            SaveData data = SaveSystem.LoadValue();

            Vector3 position;
            position.x = data.currentPosition[0];
            position.y = data.currentPosition[1];
            position.z = data.currentPosition[2];
            this.currentPosition = position;

            Vector3 velocity;
            velocity.x = data.currentVelocity[0];
            velocity.y = data.currentVelocity[1];
            velocity.z = data.currentVelocity[2];
            this.currentVelocity = velocity;

            Quaternion rotate;
            rotate.x = data.currentRotate[0];
            rotate.y = data.currentRotate[1];
            rotate.z = data.currentRotate[2];
            rotate.w = data.currentRotate[3];
            this.currentRotate = rotate;

            this.currentAngleVelocity = data.currentAngleVelocity;

            this.currentSignedAngle = data.currentSignedAngle;

            this.currentIsJump = data.currentIsJump;

            this.currentPlayTime = data.currentPlayTime;

            this.currentJumpCount = data.currentJumpCount;

            this.currentStartPos = data.currentStartPos;

            this.currentAngleSpeed = data.currentAngleSpeed;

            this.currentStage = data.currentStage;

            this.currentMass = data.currentMass;

            this.currentRainbowBlock = data.currentRainbowBlock;

            position.x = data.currentPlatformPosition0[0];
            position.y = data.currentPlatformPosition0[1];
            position.z = data.currentPlatformPosition0[2];
            this.currentPlatformPosition0 = position;

            position.x = data.currentPlatformPosition1[0];
            position.y = data.currentPlatformPosition1[1];
            position.z = data.currentPlatformPosition1[2];
            this.currentPlatformPosition1 = position;

            position.x = data.currentPlatformPosition2[0];
            position.y = data.currentPlatformPosition2[1];
            position.z = data.currentPlatformPosition2[2];
            this.currentPlatformPosition2 = position;

            position.x = data.currentPlatformNight[0];
            position.y = data.currentPlatformNight[1];
            position.z = data.currentPlatformNight[2];
            this.currentPlatformNight = position;


        }
        else
        {
            this.isLoad = false;
        }

        SceneManager.LoadScene("SunkimMap");
        this.isGameStart = true;

    }

    public void NewGame()
    {
        SceneManager.LoadScene("SunkimMap");
        this.isLoad = false;
        this.isGameStart = true;
    }

    private void Update()
    {
        if(isGameStart)
        {
            if(GameObject.Find("Player") != null && GameObject.Find("Loading") != null)
            {
                Time.timeScale = 0;

                if (isLoad)
                {
                    GameObject.Find("Player").GetComponent<Player>().LoadData();
                }
                GameObject.Find("Loading").GetComponent<LoadingUI>().Load();
            }
        }
    }

}
