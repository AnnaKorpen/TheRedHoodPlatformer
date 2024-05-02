using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    private Vector3 startingPoint;
    private SliderJoint2D sliderJoint;

    private void Awake()
    {
        startingPoint = transform.position;
        sliderJoint = GetComponent<SliderJoint2D>();
    }
    private void Update()
    {
        if(transform.position.x >= startingPoint.x + distance)
        {
            ChangeJointMotorSpeed(speed);
        }

        if(transform.position.x <= startingPoint.x)
        {
            ChangeJointMotorSpeed(-speed);
        }
    }

    private void ChangeJointMotorSpeed(float speed)
    {
        JointMotor2D jointMotor = sliderJoint.motor;
        jointMotor.motorSpeed = speed;
        sliderJoint.motor = jointMotor;
    }
}
