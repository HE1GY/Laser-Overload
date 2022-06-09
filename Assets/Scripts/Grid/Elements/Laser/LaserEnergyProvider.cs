using UnityEngine;

namespace Grid.Elements
{
    public class LaserEnergyProvider:MonoBehaviour
    {
        private const int ProvidedEnergy = 1;
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
            _laserThrower.ReceivedEnergy += ProvidedEnergy;
        }

        private  void OnDisconnect()
        {
            _laserThrower.ReceivedEnergy -= ProvidedEnergy;
            if (!_laserThrower.IsTurnOn)
            {
                _laserThrower.ResetConsumer();
            }
        }
    }

}