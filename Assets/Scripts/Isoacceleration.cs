public class Isoacceleration : ICalculator
{
    private float acceleration;
    private float initVelocity;
    private float initPosition;
    public float CalculatePosition(float time)
    {
        return acceleration * time * time / 2 + initVelocity * time + initPosition;
    }
    public Isoacceleration(float _acceleration,float init_velocity, float init_position)
    {
        this.acceleration = _acceleration;
        this.initPosition = init_position;
        this.initVelocity = init_velocity;
    }
}
