using UnityEngine;
public class SinWave : ICalculator
{
    private float amptitude;
    private float angularVelocity;
    private float initPosition;
    public float CalculatePosition(float time)
    {
        return amptitude * Mathf.Sin(angularVelocity * time) + initPosition;
    }
    public SinWave(float _amptitude ,float _angularVelocity,float _initPosition)
    {
        this.amptitude = _amptitude;
        this.angularVelocity = _angularVelocity;
        this.initPosition = _initPosition;
    }
}
