using UnityEngine;

namespace HillClimbRacingPrototype
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void LateUpdate() => FollowTarget();

        private void FollowTarget() => transform.position = target.position + offset;
    }
}