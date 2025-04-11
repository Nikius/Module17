using UnityEngine;

namespace MyAssets.Scripts.Services
{
    public class Movement
    {
        public void Move(Vector3 direction, Transform transform, float speed)
        {
            transform.position += direction.normalized * (speed * Time.deltaTime);
        }
    }
}