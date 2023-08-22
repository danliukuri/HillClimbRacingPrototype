using UnityEngine;

namespace HillClimbRacingPrototype.Player
{
    public class CarEngine : MonoBehaviour
    {
        private const float DefaultAccelerationSpeed = 1000f;
        private const float DecelerationSpeed = 0f;

        [SerializeField] private WheelJoint2D frontWheelJoint;
        [SerializeField] private WheelJoint2D rearWheelJoint;

        [SerializeField] private float accelerationSpeed = DefaultAccelerationSpeed;

        public void Accelerate() => Accelerate(accelerationSpeed);

        public void Decelerate() => Accelerate(DecelerationSpeed);

        private void Accelerate(float speed)
        {
            var motor = new JointMotor2D
            {
                motorSpeed = speed,
                maxMotorTorque = rearWheelJoint.motor.maxMotorTorque
            };

            frontWheelJoint.motor = motor;
            rearWheelJoint.motor = motor;
        }
    }
}