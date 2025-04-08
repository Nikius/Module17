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
        private readonly Enemy _enemy;
        private readonly Movement _movement;

        public Chase(Hero hero, Enemy enemy)
        {
            _hero = hero;
            _enemy = enemy;
            _movement = new Movement(enemy.transform, MoveSpeed);
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
            Vector3 direction = _hero.transform.position - _enemy.transform.position;
            _movement.Move(direction);
        }
    }
}