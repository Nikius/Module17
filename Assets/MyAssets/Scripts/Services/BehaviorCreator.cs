using System.Collections.Generic;
using MyAssets.Scripts.Behaviors;
using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Enums;
using MyAssets.Scripts.Models;
using UnityEngine;

namespace MyAssets.Scripts.Services
{
    public class BehaviorCreator: MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private ParticleSystem _blowVFXPrefab;
        
        private Enemy _enemy;
        
        public void SetEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }

        public IBehavior CreateIdleBehavior(IdleBehaviors behaviorName)
        {
            IBehavior behavior = null;
            
            switch (behaviorName)
            {
                case IdleBehaviors.Idle:
                    behavior = new Idle();
                    break;
                
                case IdleBehaviors.Patrol:
                    behavior = new Patrol(_patrolPoints, _enemy);
                    break;
                
                case IdleBehaviors.ChaoticMove:
                    behavior = new ChaoticMove(_enemy);
                    break;
                
                default:
                    Debug.LogError($"Behavior {behaviorName.ToString()} not implemented");
                    break;
            }
            
            return behavior;
        }
        
        public IBehavior CreateMeetReactionBehavior(MeetReactionBehaviors behaviorName)
        {
            IBehavior behavior = null;
            
            switch (behaviorName)
            {
                case MeetReactionBehaviors.RunAway:
                    behavior = new RunAway(_hero, _enemy);
                    break;
                
                case MeetReactionBehaviors.Chase:
                    behavior = new Chase(_hero, _enemy);
                    break;

                case MeetReactionBehaviors.SelfDestroy:
                    ParticleSystem blowVFX = Instantiate(_blowVFXPrefab, _enemy.transform.position, Quaternion.identity);
                    behavior = new SelfDestroy(_enemy, blowVFX);
                    break;

                default:
                    Debug.LogError($"Behavior {behaviorName.ToString()} not implemented");
                    break;
            }
            
            return behavior;
        }
    }
}