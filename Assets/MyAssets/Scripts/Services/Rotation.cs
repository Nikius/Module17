using UnityEngine;

namespace MyAssets.Scripts.Services
{
    public class Rotation
    {
        private readonly float _rotationSpeed;
        private readonly Transform _transform;

        public Rotation(Transform transform, float rotationSpeed)
        {
            _transform = transform;
            _rotationSpeed = rotationSpeed;
        }
    
        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = _rotationSpeed * Time.deltaTime;
        
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }
    }
}
