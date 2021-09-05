using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float angleSpeed = 1000f;

    [SerializeField]
    private GameObject endingWall;

    public bool isJump = false;
    public bool canJump = false;
    public bool isStop = false;
    public bool isGameClear = false;

    private float signedAngle;
    private bool isCollisionDelay = false;

    private float collisionDelayAmount = 0.1f;

    private float collisionDelayTick = 0;

    private bool isCheckCanJump = false;
    private float canJumpTick = 0f;

    //현제 최고 스테이지
    private int achieveStage = 0;

    //점프 수
    private int jumpCount = 0;

    //플레이 타임
    public float playtime = 0;


    // 스테이지별 대사 모음
    private const string stage1 = "I wanna be a Star!";
    private const string stage2 = "Fresh Air~";
    private const string stage3 = "Wow! Mountain!";
    private const string stage4 = "Step to rainbow color!";
    private const string stage5 = "BIG Sun!!";
    private const string stage6 = "Feel lighter!";
    private const string stage7 = "Almost Star!";

    //높이 떨어졌을 때 대사
    private string[] fallText = new string[]{
        "shit...",
        "LoL! ",
        "Don't give up!",
        "Not Bad...",
        "OMG...",
        };

    private float startPos;
    private float endPos;

    [SerializeField]
    private float fallDistance = 20.0f;


    // 세이브 프레임
    private const int SAVE_BY_FRAMES = 12;
    private int currentFrame = 0;

    //레인보우
    public int rainbowBlock = 0;

    //썬셋
    public GameObject platform0;
    public GameObject platform1;
    public GameObject platform2;

    //나이트스카이
    public GameObject platformNight;

    void Start()
    {
    }

    public int GetJumpCount()
    {
        return this.jumpCount;
    }

    public int GetPlayTime()
    {
        return (int)this.playtime;
    }

    private void FixedUpdate()
    {
        if (isGameClear)
        {
            return;
        }

        playtime += Time.deltaTime;
    }

    void Update()
    { 
        if(isGameClear)
        {
            return;
        }

        currentFrame++;

        if(currentFrame >= SAVE_BY_FRAMES)
        {
            ValueController.getInstance().currentPosition = transform.position;
            ValueController.getInstance().currentVelocity = GetComponent<Rigidbody2D>().velocity;
            ValueController.getInstance().currentRotate = transform.rotation;
            ValueController.getInstance().currentAngleVelocity = GetComponent<Rigidbody2D>().angularVelocity;
            ValueController.getInstance().currentSignedAngle = this.signedAngle;
            ValueController.getInstance().currentIsJump = this.isJump;
            ValueController.getInstance().currentPlayTime = this.playtime;
            ValueController.getInstance().currentJumpCount = this.jumpCount;
            ValueController.getInstance().currentStartPos = this.startPos;
            ValueController.getInstance().currentAngleSpeed = this.angleSpeed;
            ValueController.getInstance().currentStage = this.achieveStage;
            ValueController.getInstance().currentMass = GetComponent<Rigidbody2D>().mass;
            ValueController.getInstance().currentRainbowBlock = this.rainbowBlock;
            ValueController.getInstance().currentPlatformPosition0 = platform0.transform.position;
            ValueController.getInstance().currentPlatformPosition1 = platform1.transform.position;
            ValueController.getInstance().currentPlatformPosition2 = platform2.transform.position;
            ValueController.getInstance().currentPlatformNight = platformNight.transform.position;
            ValueController.getInstance().SaveData();
            currentFrame = 0;
        }

        if (transform.position.y >= 180)
        {
            isGameClear = true;
            BGMManager.getInstance().PlaySound(BGMManager.getInstance().clearBGM);
            gameObject.GetComponent<EndingScript>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            SaveSystem.DeleteSave();
            //플레이어의 jumpCount와 playTime을 리더보드에 올리는 함수를 넣으면 될 것 같습니다! 
            // 플레이 타임을 시 분 초로 변환하는 작업은 PlayTimeDisplay 스크립트 참고 부탁드려요
            Destroy(endingWall);
        }

        float stopThreshold = 0.001f;

        if (GetComponent<Rigidbody2D>().velocity.magnitude <= stopThreshold)
        {
            isStop = true;
        } else
        {
            isStop = false;
        }


        if (isJump)
        {
            collisionDelayTick += Time.deltaTime;
            if(collisionDelayTick > collisionDelayAmount)
            {
                isCollisionDelay = true;
            }
            transform.Rotate(Vector3.forward * signedAngle * Time.deltaTime * angleSpeed);
        }

        if(isCheckCanJump)
        {
            canJumpTick += Time.deltaTime;
            if(canJumpTick > 0.1)
            {
                canJump = true;
                FalledProcess();
                isCheckCanJump = false;
            }
        }

        if(transform.position.y < 117.33)
        {
            GetComponent<Rigidbody2D>().mass = 1f;
        } else
        {
            GetComponent<Rigidbody2D>().mass = 0.7f;
        }

    }


    public void Jump(int side)
    {
        signedAngle = side;
        isJump = true;
    }

    public void SetStartPos()
    {
        startPos = transform.position.y;
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("SideWall"))
        {
            return;
        }

        canJumpTick = 0;
        isCheckCanJump = true;
        ModifiedDataWithStage();

        if (isCollisionDelay)
        {
            isJump = false;
            isCollisionDelay = false;
            collisionDelayTick = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("SideWall"))
        {
            return;
        }
        isCheckCanJump = false;
        canJump = false;
    }

    private void ModifiedDataWithStage()
    {
        if(transform.position.y < 13.4)
        {
            angleSpeed = 100;
            //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            if(achieveStage < 1)
            {
                achieveStage = 1;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage1);
            }
        } 
        else if (transform.position.y < 39.33)
        {
            angleSpeed = 300;
           // GetComponent<SpriteRenderer>().color = new Color(1, 0.9843137f, 0.9411765f);
            if (achieveStage < 2)
            {
                achieveStage = 2;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage2);
            }
        }
        else if (transform.position.y < 65.33)
        {
            //GetComponent<SpriteRenderer>().color = new Color(1, 0.9568627f, 0.8470588f);
            angleSpeed = 600;
            if (achieveStage < 3)
            {
                achieveStage = 3;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage3);
            }
        }
        else if (transform.position.y < 91.33)
        {
           // GetComponent<SpriteRenderer>().color = new Color(1, 0.9372549f, 0.7607843f);
            angleSpeed = 900;
            if (achieveStage < 4)
            {
                achieveStage = 4;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage4);
            }
        }
        else if (transform.position.y < 117.33)
        {
            //GetComponent<SpriteRenderer>().color = new Color(1, 0.9098039f, 0.6784314f);
            angleSpeed = 1200;
            if (achieveStage < 5)
            {
                achieveStage = 5;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage5);
            }
        }
        else if (transform.position.y < 143.34)
        {
           // GetComponent<SpriteRenderer>().color = new Color(1, 0.8745098f, 0.5333334f);
            angleSpeed = 1500;
            if (achieveStage < 6)
            {
                achieveStage = 6;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage6);
            }
        }
        else if (transform.position.y < 169)
        {
           // GetComponent<SpriteRenderer>().color = new Color(1, 0.8352941f, 0.4039216f);
            angleSpeed = 1800;
            if (achieveStage < 7)
            {
                achieveStage = 7;
                GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage7);
            }
        }
        else
        {
           // GetComponent<SpriteRenderer>().color = new Color(0.9803922f, 0.7647059f, 0.1960784f);
            angleSpeed = 1800;
            if (achieveStage < 8)
            {
                achieveStage = 8;
                //GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(stage8);
            }
        }
    }

    private void FalledProcess()
    {
        endPos = transform.position.y;
        if(startPos - endPos > fallDistance)
        {
            startPos = endPos;
            int choice = Random.Range(0, fallText.Length);
            GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText(fallText[choice]);
        }
    }

    public void ClickRestart()
    {
        BGMManager.getInstance().StopSound();
        SceneManager.LoadScene("SunkimMap");
    }

    public void LoadData()
    {
        transform.position = ValueController.getInstance().currentPosition;
        GetComponent<Rigidbody2D>().velocity = ValueController.getInstance().currentVelocity;
        transform.rotation = ValueController.getInstance().currentRotate;
        GetComponent<Rigidbody2D>().angularVelocity = ValueController.getInstance().currentAngleVelocity;
        this.signedAngle = ValueController.getInstance().currentSignedAngle;
        this.isJump = ValueController.getInstance().currentIsJump;
        this.playtime = ValueController.getInstance().currentPlayTime;
        this.jumpCount = ValueController.getInstance().currentJumpCount;
        this.startPos = ValueController.getInstance().currentStartPos;
        this.angleSpeed = ValueController.getInstance().currentAngleSpeed;
        this.achieveStage = ValueController.getInstance().currentStage;
        GetComponent<Rigidbody2D>().mass = ValueController.getInstance().currentMass;
        GameObject.Find("RainbowManager").GetComponent<RainbowBlockManager>().LoadCollider(ValueController.getInstance().currentRainbowBlock);
        platform0.transform.position = ValueController.getInstance().currentPlatformPosition0;
        platform1.transform.position = ValueController.getInstance().currentPlatformPosition1;
        platform2.transform.position = ValueController.getInstance().currentPlatformPosition2;
        platformNight.transform.position = ValueController.getInstance().currentPlatformNight;
    }
}
