using System.Collections.Generic;
using MyAssets.Scripts.Behaviors.Contracts;
using MyAssets.Scripts.Services;
using UnityEngine;

namespace MyAssets.Scripts.Models
{
    public class Spawner: MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
 
        private BehaviorCreator _behaviorCreator;

        private void Awake()
        {
            _behaviorCreator = GetComponent<BehaviorCreator>();
        }

        private void Start()
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                
                IBehavior idleBehavior = _behaviorCreator.CreateIdleBehavior(
                    enemy.gameObject,
                    spawnPoint.idleBehaviorEnumType
                );
                IBehavior meetReactionBehavior = _behaviorCreator.CreateMeetReactionBehavior(
                    enemy.gameObject,
                    spawnPoint.meetReactionBehaviorEnumType
                );
                
                enemy.Initialize(idleBehavior, meetReactionBehavior);
            }
        }
    }
}