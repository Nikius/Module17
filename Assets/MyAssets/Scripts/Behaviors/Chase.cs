using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using MyAssets.Scripts.Services;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class Chase: IBehavior
    {
        private const float MoveSpeed = 8f;
        
        private readonly Hero _hero;
        private readonly Transform _moverTransform;
        private readonly Movement _movement;

        public Chase(Hero hero, Transform moverTransform)
        {
            _hero = hero;
            _moverTransform = moverTransform;
            _movement = new Movement();
        }
        
        public void Enter()
        {
            Debug.Log("Chase");
        }

        public void Update()
        {
            Move();
        }
        
        private void Move()
        {
            Vector3 direction = _hero.transform.position - _moverTransform.transform.position;
            _movement.Move(direction, _moverTransform.transform, MoveSpeed);
        }
    }
}