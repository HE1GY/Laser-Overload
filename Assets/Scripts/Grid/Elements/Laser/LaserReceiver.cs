using System;
using UnityEngine;

namespace Grid.Elements
{
    public class LaserReceiver:MonoBehaviour
    {
        public event Action Connected;
        public event Action LostConnection;
        
        [SerializeField] private Collider2D _recieveCollider;

        public bool TryConnect(Collider2D collider2D)
        {
            if (_recieveCollider.Equals(collider2D))
            {
                Connected?.Invoke();
                return true;
            }
            return false;
        }

        public void Disconnect(Collider2D collider2D)
        {
            if (_recieveCollider.Equals(collider2D))
            {
                LostConnection?.Invoke();
            }
        }
    }
}