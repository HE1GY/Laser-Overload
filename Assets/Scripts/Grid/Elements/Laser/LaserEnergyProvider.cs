using UnityEngine;

namespace Grid.Elements
{
    public class LaserEnergyProvider:MonoBehaviour
    {
        [SerializeField] private LaserReceiver _laserReceiver;
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
        
        
        private  void OnConnected()
        {
            _laserThrower.IsThrowingLaser = true;
        }

        private  void OnDisconnect()
        {
            _laserThrower.IsThrowingLaser = false;
            _laserThrower.StopThrowing();
        }
    }

}