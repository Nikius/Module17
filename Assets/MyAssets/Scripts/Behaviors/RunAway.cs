using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using MyAssets.Scripts.Services;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class RunAway: IBehavior
    {
        private const float MoveSpeed = 8f;
        
        private readonly Hero _hero;
        private readonly Transform _moverTransform;
        private readonly Movement _movement;

        public RunAway(Hero hero, Transform moverTransform)
        {
            _hero = hero;
            _moverTransform = moverTransform;
            _movement = new Movement();
        }
        
        public void Enter()
        {
            Debug.Log("RunAway");
        }
        
        public void Update()
        {
            Move();
        }
        
        private void Move()
        {
            Vector3 direction = _moverTransform.transform.position - _hero.transform.position;
            direction.y = 0;
            _movement.Move(direction, _moverTransform.transform, MoveSpeed);
        }
    }
}