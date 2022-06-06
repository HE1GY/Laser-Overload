using System;
using UnityEngine;

namespace Grid.Elements
{
    public class LaserReceiver:MonoBehaviour
    {
        public event Action<Collider2D> Connected;
        public event Action<Collider2D> LostConnection;
        
        [SerializeField] private Collider2D[] _recieveColliders;

        public bool TryConnect(Collider2D collider2D)
        {
            foreach (var collider in _recieveColliders)
            {
                if (collider.Equals(collider2D))
                {
                    Connected?.Invoke(collider);
                    return true;
                }
            }
            return false;
        }

        public void Disconnect(Collider2D collider2D)
        {
            LostConnection?.Invoke(collider2D);
        }
    }
}