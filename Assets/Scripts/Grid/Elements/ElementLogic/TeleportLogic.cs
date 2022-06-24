using Grid.Elements;
using UnityEngine;

namespace Grid
{
    public class TeleportLogic : MonoBehaviour, IElementLogic
    {
        [SerializeField] private LaserReceiver[] _laserReceivers;
        [SerializeField] private LaserEnergyProvider[] _laserEnergyProviders;

        public LaserReceiver[] LaserReceivers => _laserReceivers;

        public void SetLaserReceiversToLaser(LaserReceiver[] laserReceivers)
        {
            for (int i = 0; i < _laserEnergyProviders.Length; i++)
            {
                _laserEnergyProviders[i].LaserReceiver = laserReceivers[i];
            }
        }
        
    }
}