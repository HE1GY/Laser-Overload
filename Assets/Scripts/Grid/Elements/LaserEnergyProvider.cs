using System;
using UnityEngine;

namespace Grid.Elements
{
    [RequireComponent(typeof(LaserReceiver))]
    public class LaserEnergyProvider:MonoBehaviour
    {
        [SerializeField] private Collider2D _receiverPort;
        [SerializeField] private LaserThrower _laserThrower;
        
        private LaserReceiver _laserReceiver;

        private void Awake()
        {
            _laserReceiver = GetComponent<LaserReceiver>();
        }

        private void OnEnable()
        {
            _laserReceiver.Connected += OnConnected;
            _laserReceiver.LostConnection+=OnDisconnect;
        }

        private void OnDisable()
        {
            _laserReceiver.Connected -= OnConnected;
            _laserReceiver.LostConnection -= OnDisconnect;
        }
        
        
        private void OnConnected(Collider2D collider2D)
        {
            if (_receiverPort.Equals(collider2D))
            {
                _laserThrower.IsThrowingLaser = true;
            }
        }

        private void OnDisconnect(Collider2D collider2D)
        {
            if (_receiverPort.Equals(collider2D))
            {
                _laserThrower.IsThrowingLaser = false;
                _laserThrower.StopThrowing();
            }
        }
    }
}