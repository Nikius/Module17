using System.Collections.Generic;
using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using MyAssets.Scripts.Services;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class Patrol: IBehavior
    {
        private const float MoveSpeed = 8f;
        private const float MinDistance = 0.05f;

        private readonly Queue<Vector3> _patrolQueue = new();
        private readonly Transform _moverTransform;

        private readonly Movement _movement;
        
        private Vector3 _currentTarget;

        public Patrol(List<Transform> patrolPoints, Transform moverTransform)
        {
            _moverTransform = moverTransform;
            _movement = new Movement();
            
            foreach (var point in patrolPoints)
            {
                _patrolQueue.Enqueue(point.position);
            }
        }
        
        public void Enter()
        {
            Debug.Log("Patrol");
            
            SwitchPatrolPoint();
        }

        public void Update()
        {
            Move();
        }
        
        private void Move()
        {
            Vector3 direction = GetDirectionToPatrolPoint();
        
            if (direction.magnitude <= MinDistance)
                SwitchPatrolPoint();
        
            _movement.Move(direction, _moverTransform.transform, MoveSpeed);
        }
        
        private Vector3 GetDirectionToPatrolPoint() => _currentTarget - _moverTransform.transform.position;
        
        private void SwitchPatrolPoint()
        {
            _currentTarget = _patrolQueue.Dequeue();
            _patrolQueue.Enqueue(_currentTarget);
        }
    }
}