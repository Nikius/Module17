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
                
                _behaviorCreator.SetEnemy(enemy);
                
                IBehavior idleBehavior = _behaviorCreator.CreateIdleBehavior(spawnPoint.idleBehaviorType);
                IBehavior meetReactionBehavior = _behaviorCreator.CreateMeetReactionBehavior(spawnPoint.meetReactionBehaviorType);
                
                enemy.Initialize(idleBehavior, meetReactionBehavior);
            }
        }
    }
}