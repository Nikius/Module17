using UnityEngine;

namespace MyAssets.Scripts.Services
{
    public class Rotation
    {
        public void RotateTo(Transform transform, float rotationSpeed, Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = rotationSpeed * Time.deltaTime;
        
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
    }
}
