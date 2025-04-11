using System.Collections.Generic;
using MyAssets.Scripts.Behaviors;
using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Models;
using UnityEngine;

namespace MyAssets.Scripts.Services
{
    public class BehaviorCreator: MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private ParticleSystem _blowVFXPrefab;
        
        public IBehavior CreateIdleBehavior(GameObject ownerGameObject, IdleBehaviorsEnum behaviorEnumName)
        {
            IBehavior behavior = null;
            
            switch (behaviorEnumName)
            {
                case IdleBehaviorsEnum.Idle:
                    behavior = new Idle();
                    break;
                
                case IdleBehaviorsEnum.Patrol:
                    behavior = new Patrol(_patrolPoints, ownerGameObject.transform);
                    break;
                
                case IdleBehaviorsEnum.ChaoticMove:
                    behavior = new ChaoticMove(ownerGameObject.transform);
                    break;
                
                default:
                    Debug.LogError($"Behavior {behaviorEnumName.ToString()} not implemented");
                    break;
            }
            
            return behavior;
        }
        
        public IBehavior CreateMeetReactionBehavior(GameObject ownerGameObject, MeetReactionBehaviorsEnum behaviorEnumName)
        {
            IBehavior behavior = null;
            
            switch (behaviorEnumName)
            {
                case MeetReactionBehaviorsEnum.RunAway:
                    behavior = new RunAway(_hero, ownerGameObject.transform);
                    break;
                
                case MeetReactionBehaviorsEnum.Chase:
                    behavior = new Chase(_hero, ownerGameObject.transform);
                    break;

                case MeetReactionBehaviorsEnum.SelfDestroy:
                    ParticleSystem blowVFX = Instantiate(_blowVFXPrefab, ownerGameObject.transform.position, Quaternion.identity);
                    behavior = new SelfDestroy(ownerGameObject, blowVFX);
                    break;

                default:
                    Debug.LogError($"Behavior {behaviorEnumName.ToString()} not implemented");
                    break;
            }
            
            return behavior;
        }
    }
}