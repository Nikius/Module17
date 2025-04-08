using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class SelfDestroy: IBehavior
    {
        private readonly Enemy _enemy;
        private readonly ParticleSystem _blowVFX;
        
        public SelfDestroy(Enemy enemy, ParticleSystem blowVFX)
        {
            _enemy = enemy;
            _blowVFX = blowVFX;
        }
        
        public void Update()
        {
            _blowVFX.Play();
            Object.Destroy(_blowVFX.gameObject, _blowVFX.main.duration);
            _enemy.Destroy();
        }
        
        public void Enter()
        {
            Debug.Log("SelfDestroy");
            
            _blowVFX.gameObject.transform.position = _enemy.transform.position;
        }
    }
}