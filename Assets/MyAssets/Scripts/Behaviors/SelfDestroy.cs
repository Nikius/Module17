using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class SelfDestroy: IBehavior
    {
        private readonly GameObject _ownerGameObject;
        private readonly ParticleSystem _blowVFX;
        
        private bool _isDestroying = false;
        
        public SelfDestroy(GameObject ownerGameObject, ParticleSystem blowVFX)
        {
            _ownerGameObject = ownerGameObject;
            _blowVFX = blowVFX;
        }
        
        public void Update()
        {
            if (_isDestroying)
                return;
            
            _isDestroying = true;
            _blowVFX.Play();
            Object.Destroy(_blowVFX.gameObject, _blowVFX.main.duration);
            Object.Destroy(_ownerGameObject);
        }
        
        public void Enter()
        {
            Debug.Log("SelfDestroy");
            
            _blowVFX.gameObject.transform.position = _ownerGameObject.transform.position;
        }
    }
}