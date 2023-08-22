using UnityEngine;

namespace HillClimbRacingPrototype.Player
{
    public class CarEngine : MonoBehaviour
    {
        private const float DefaultMaxMotorSpeed = 2000f;
        private const float MovingDirection = -1f;
        private const float DefaultAccelerationSpeed = 2f;
        private const float DefaultDecelerationSpeed = 1f;

        [SerializeField] private WheelJoint2D frontWheelJoint;
        [SerializeField] private WheelJoint2D rearWheelJoint;
        
        [SerializeField] private float defaultMotorSpeed;
        [SerializeField] private float maxMotorSpeed = DefaultMaxMotorSpeed;

        [SerializeField]  private float accelerationSpeed = DefaultAccelerationSpeed;
        [SerializeField]  private float decelerationSpeed = DefaultDecelerationSpeed;
        
        private float _accelerationVelocity;
        private float _decelerationVelocity;
        private JointMotor2D _motor;

        private void Awake()
        {
            _motor = new JointMotor2D { motorSpeed = defaultMotorSpeed, maxMotorTorque = maxMotorSpeed };
            frontWheelJoint.motor = _motor;
            rearWheelJoint.motor = _motor;
        }

        public void Accelerate()
        {
            SetMotorSpeed(Mathf.SmoothDamp(_motor.motorSpeed, MovingDirection * maxMotorSpeed,
                ref _accelerationVelocity, accelerationSpeed));
        }

        public void Decelerate()
        {
            SetMotorSpeed(Mathf.SmoothDamp(_motor.motorSpeed, MovingDirection * defaultMotorSpeed,
                ref _decelerationVelocity, decelerationSpeed));
        }

        public void Brake() => SetMotorSpeed(MovingDirection * defaultMotorSpeed);

        private void SetMotorSpeed(float speed)
        {
            _motor.motorSpeed = speed;
            frontWheelJoint.motor = _motor;
            rearWheelJoint.motor = _motor;
        }
    }
}