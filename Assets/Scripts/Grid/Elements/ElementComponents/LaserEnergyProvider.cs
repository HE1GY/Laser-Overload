#region

using UnityEngine;

#endregion

namespace Grid.Elements
{
    public class LaserEnergyProvider : EnergyReceiver
    {
        [SerializeField] private LaserThrower _laserThrower;

        protected override void OnEnable()
        {
            base.OnEnable();
            _laserThrower.ResetEnergy += OnResetEnergy;
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            _laserThrower.ResetEnergy += OnResetEnergy;
        }


        private void OnResetEnergy()
        {
            ReceivedEnergy = 0;
        }

        protected override void AfterStartReceiving()
        {
            _laserThrower.ReceivedEnergy = ReceivedEnergy;
            if (_laserThrower.IsTurnOn)
            {
                _laserThrower.IsFirstSideConnection = true;
                _laserThrower.CallDrawing();
            }
        }

        protected override void AfterEndReceiving()
        {
            var pastIsTurnOn = _laserThrower.IsTurnOn;
            _laserThrower.ReceivedEnergy = ReceivedEnergy;
            if (pastIsTurnOn != _laserThrower.IsTurnOn)
            {
                _laserThrower.ResetConsumer();
                _laserThrower.CallDrawing();
            }
        }
    }
}