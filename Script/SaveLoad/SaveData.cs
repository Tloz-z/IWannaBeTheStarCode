using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public float[] currentPosition;
    public float[] currentVelocity;
    public float[] currentRotate;
    public float currentAngleVelocity;
    public float currentSignedAngle;
    public bool currentIsJump;
    public float currentPlayTime;
    public int currentJumpCount;
    public float currentStartPos;
    public float currentAngleSpeed;
    public int currentStage;
    public float currentMass;

    //rainbow
    public int currentRainbowBlock;

    //sunset
    public float[] currentPlatformPosition0;
    public float[] currentPlatformPosition1;
    public float[] currentPlatformPosition2;

    //nightSky
    public float[] currentPlatformNight;
    public SaveData(ValueController valueController)
    {
        currentPosition = new float[3];
        currentPosition[0] = valueController.currentPosition.x;
        currentPosition[1] = valueController.currentPosition.y;
        currentPosition[2] = valueController.currentPosition.z;

        currentVelocity = new float[3];
        currentVelocity[0] = valueController.currentVelocity.x;
        currentVelocity[1] = valueController.currentVelocity.y;
        currentVelocity[2] = valueController.currentVelocity.z;

        currentRotate = new float[4];
        currentRotate[0] = valueController.currentRotate.x;
        currentRotate[1] = valueController.currentRotate.y;
        currentRotate[2] = valueController.currentRotate.z;
        currentRotate[3] = valueController.currentRotate.w;

        currentAngleVelocity = valueController.currentAngleVelocity;

        currentSignedAngle = valueController.currentSignedAngle;

        currentIsJump = valueController.currentIsJump;

        currentPlayTime = valueController.currentPlayTime;
        
        currentJumpCount = valueController.currentJumpCount;

        currentStartPos = valueController.currentStartPos;

        currentAngleSpeed = valueController.currentAngleSpeed;

        currentStage = valueController.currentStage;

        currentMass = valueController.currentMass;

        currentRainbowBlock = valueController.currentRainbowBlock;

        currentPlatformPosition0 = new float[3];
        currentPlatformPosition0[0] = valueController.currentPlatformPosition0.x;
        currentPlatformPosition0[1] = valueController.currentPlatformPosition0.y;
        currentPlatformPosition0[2] = valueController.currentPlatformPosition0.z;

        currentPlatformPosition1 = new float[3];
        currentPlatformPosition1[0] = valueController.currentPlatformPosition1.x;
        currentPlatformPosition1[1] = valueController.currentPlatformPosition1.y;
        currentPlatformPosition1[2] = valueController.currentPlatformPosition1.z;

        currentPlatformPosition2 = new float[3];
        currentPlatformPosition2[0] = valueController.currentPlatformPosition2.x;
        currentPlatformPosition2[1] = valueController.currentPlatformPosition2.y;
        currentPlatformPosition2[2] = valueController.currentPlatformPosition2.z;

        currentPlatformNight = new float[3];
        currentPlatformNight[0] = valueController.currentPlatformNight.x;
        currentPlatformNight[1] = valueController.currentPlatformNight.y;
        currentPlatformNight[2] = valueController.currentPlatformNight.z;
    }

}
