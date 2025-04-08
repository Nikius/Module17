using UnityEngine;

namespace MyAssets.Scripts.Services
{
    public class Movement
    {
        private readonly float _speed;
        private readonly Transform _transform;

        public Movement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }
        
        public void Move(Vector3 direction)
        {
            _transform.position += direction.normalized * (_speed * Time.deltaTime);
        }
    }
}