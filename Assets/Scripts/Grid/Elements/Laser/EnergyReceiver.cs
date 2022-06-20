using UnityEngine;

namespace Grid.Elements
{
    public abstract class EnergyReceiver : MonoBehaviour
    {
        [SerializeField] private LaserReceiver _laserReceiver;
        private int _energyStep = 1;
        protected int ReceivedEnergy;

        protected virtual void OnEnable()
        {
            _laserReceiver.Connected += OnStartReceiving;
            _laserReceiver.LostConnection += OnEndReceiving;
        }

        protected virtual void OnDisable()
        {
            _laserReceiver.Connected -= OnStartReceiving;
            _laserReceiver.LostConnection -= OnEndReceiving;
        }

        private void OnStartReceiving()
        {
            ReceivedEnergy += _energyStep;
            AfterStartReceiving();
        }

        private void OnEndReceiving()
        {
            if (ReceivedEnergy > 0) ReceivedEnergy -= _energyStep;
            AfterEndReceiving();
        }

        protected abstract void AfterStartReceiving();
        protected abstract void AfterEndReceiving();
    }
}