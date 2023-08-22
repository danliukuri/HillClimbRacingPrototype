using HillClimbRacingPrototype.UI;
using UnityEngine;

namespace HillClimbRacingPrototype.Player
{
    public class PlayerCarController : MonoBehaviour
    {
        [SerializeField] private CarEngine carEngine;

        [SerializeField] private ButtonEventsHandler accelerationButton;
        [SerializeField] private ButtonEventsHandler decelerationButton;

        private void FixedUpdate()
        {
            if (accelerationButton.IsPressed)
                carEngine.Accelerate();
            else if (decelerationButton.IsPressed)
                carEngine.Brake();
            else
                carEngine.Decelerate();
        }
    }
}