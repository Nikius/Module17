using MyAssets.Scripts.Behaviors.Contracts;
using UnityEngine;

namespace MyAssets.Scripts.Behaviors
{
    public class Idle: IBehavior
    {
        public void Enter()
        {
            Debug.Log("Idle");
        }
        public void Update()
        {
        }
    }
}