using MyAssets.Scripts.Services;
using UnityEngine;

namespace MyAssets.Scripts.Controllers
{
    public class InputMovement : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const float MinMove = 0.05f;
        
        private Movement _movement;
        private Rotation _rotation;
        
        private void Awake()
        {
            _movement = new Movement(transform, 10);
            _rotation = new Rotation(transform, 500);
        }

        private void Update()
        {
            var direction = GetDirection();

            if (direction.magnitude >= MinMove)
            {
                _movement.Move(direction);
                _rotation.RotateTo(direction);
            }
        }

        private static Vector3 GetDirection()
        {
            float inputX = -Input.GetAxis(HorizontalAxis);
            float inputZ = -Input.GetAxis(VerticalAxis);

            return new Vector3(inputX, 0, inputZ);
        }
    }
}
