using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using MyAssets.Scripts.Services;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class ChaoticMove: IBehavior
    {
        private const float MoveDuration = 1f;
        private const float MoveSpeed = 4f;
        private const float Distance = MoveDuration * MoveSpeed;

        private readonly Transform _moverTransform;
        private readonly Movement _movement;
        
        private float _timer;
        private Vector3 _targetPosition;

        public ChaoticMove(Transform moverTransform)
        {
            _moverTransform = moverTransform;
            _movement = new Movement();
        }

        public void Enter()
        {
            Debug.Log("ChaoticMove");
            
            ResetTimer();
            SetTarget();
        }
        
        public void Update()
        {
            _timer -= Time.deltaTime;
            
            if (_timer <= 0)
            {
                SetTarget();
                ResetTimer();
            }

            Move();
        }

        private void ResetTimer() => _timer = MoveDuration;

        private void SetTarget()
        {
            float angle = Random.Range(0f, 360f);
            _targetPosition = new Vector3(Distance * Mathf.Cos(angle), 0, Distance * Mathf.Sin(angle));
        }

        private void Move()
        {
            _movement.Move(_targetPosition, _moverTransform.transform, MoveSpeed);
        }
    }
}