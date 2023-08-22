using UnityEngine;

namespace HillClimbRacingPrototype
{
    public class PlayerMover : MonoBehaviour
    {
        private const float DefaultSpeed = 1000f;

        [SerializeField] private WheelJoint2D frontWheelJoint;
        [SerializeField] private WheelJoint2D rearWheelJoint;
        [SerializeField] private float speed = DefaultSpeed;

        private float _movementDirection;

        private void Update() => UpdateMovementDirection();

        private void FixedUpdate() => Move();

        private void UpdateMovementDirection()
        {
            const string movementDirectionAxisName = "Horizontal";
            _movementDirection = -Input.GetAxis(movementDirectionAxisName);
        }

        private void Move()
        {
            var motor = new JointMotor2D
            {
                motorSpeed = _movementDirection * speed,
                maxMotorTorque = rearWheelJoint.motor.maxMotorTorque
            };

            frontWheelJoint.motor = motor;
            rearWheelJoint.motor = motor;
        }
    }
}