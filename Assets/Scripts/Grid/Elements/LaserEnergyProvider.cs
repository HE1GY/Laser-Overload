using UnityEngine;

namespace Grid.Elements
{
    public class LaserEnergyProvider:MonoBehaviour
    {
        [SerializeField] private LaserReceiver _laserReceiver;
        [SerializeField] private Collider2D _receiverPort;
        
        [SerializeField] private LaserThrower _laserThrower;
        
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
            }
        }
    }
}