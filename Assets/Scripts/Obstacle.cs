using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    private float initTime;
    private ICalculator calculatorX;
    private ICalculator calculatorY;
    public CalclatorXType_t CalculatorXType;
    public CalclatorYType_t CalculatorYType;
    private float modifideV;
    public enum CalclatorXType_t {
        LINEAR,
        ISOACCELERATION_UP,
        ISOACCELERATION_DOWN
    }
    public enum CalclatorYType_t {
        STAY,
        SIN_UP,
        SIN_DOWN,
        ISOACCELERATION_UP,
        ISOACCELERATION_DOWN
    }

    public void Init(float initPositionX,float initPositionY)
    {
        float ax = -1f;
        float V0 = -Mathf.Sqrt(2 * ax * -30f);
        float V = -3f;
        float modifideV = -CountDistance.time/10f;
        transform.position = new Vector2(initPositionX, initPositionY);
        initTime = 0f;
        switch (CalculatorXType)
        {
            case CalclatorXType_t.LINEAR:
                calculatorX = new Isoacceleration(0, V+modifideV, initPositionX);
                break;
            case CalclatorXType_t.ISOACCELERATION_UP:
                calculatorX = new Isoacceleration(ax, 0+modifideV, initPositionX);
                break;
            case CalclatorXType_t.ISOACCELERATION_DOWN:
                calculatorX = new Isoacceleration(-ax, V0+modifideV, initPositionX);
                break;
        }
        float A = 0.7f;
        float W = 0.7f * Mathf.PI;
        float ay = 0.23f;
        switch (CalculatorYType)
        {
            case CalclatorYType_t.STAY:
                calculatorY = new Isoacceleration(0, 0, initPositionY);
                break;
            case CalclatorYType_t.SIN_UP:
                calculatorY = new SinWave(A, W, initPositionY);
                break;
            case CalclatorYType_t.SIN_DOWN:
                calculatorY = new SinWave(-A, W, initPositionY);
                break;
            case CalclatorYType_t.ISOACCELERATION_UP:
                calculatorY = new Isoacceleration(ay, 0, initPositionY);
                break;
            case CalclatorYType_t.ISOACCELERATION_DOWN:
                calculatorY = new Isoacceleration(-ay, 0, initPositionY);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        initTime += Time.fixedDeltaTime;//+ Time.realtimeSinceStartup/120f ;
        //initTime = initTime * Time.realtimeSinceStartup / 120f;
        //float scaledtime = time * (1 + timerate * time);
        transform.position = new Vector2(calculatorX.CalculatePosition(initTime), calculatorY.CalculatePosition(initTime));
        if (transform.position.x < -10f) { Destroy(this.gameObject); }
        //Debug.Log(time.ToString() +" "+ scaledtime.ToString());
    }
}
