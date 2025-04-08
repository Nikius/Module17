using System;
using MyAssets.Scripts.Behaviors.Contracts;
using UnityEngine;

namespace MyAssets.Scripts.Models
{
    public class Enemy: MonoBehaviour
    {
        private const string HeroTag = "Hero";
        
        private IBehavior _idleBehavior;
        private IBehavior _meetReactionBehavior;
        private IBehavior _currentBehavior;

        private void SetCurrentBehavior(IBehavior behavior)
        {
            _currentBehavior = behavior;
            _currentBehavior.Enter();
        }

        public void Initialize(IBehavior idleBehavior, IBehavior meetReactionBehavior)
        {
            _idleBehavior = idleBehavior;
            _meetReactionBehavior = meetReactionBehavior;

            SetCurrentBehavior(idleBehavior);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(HeroTag))
                SetCurrentBehavior(_meetReactionBehavior);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(HeroTag))
                SetCurrentBehavior(_idleBehavior);
        }

        private void Update()
        {
            _currentBehavior.Update();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}