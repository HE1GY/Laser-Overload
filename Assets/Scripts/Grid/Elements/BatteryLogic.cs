#region

using System;
using Grid.Elements;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class BatteryLogic : EnergyReceiver
{
    [SerializeField] private Image _testMark; //test
    public bool IsCharged { get; private set; }

    public event Action Chargered;

    protected override void AfterStartReceiving()
    {
        if (ReceivedEnergy > 0)
        {
            IsCharged = true;
            _testMark.enabled = true;
            Chargered?.Invoke();
        }
    }

    protected override void AfterEndReceiving()
    {
        if (ReceivedEnergy == 0)
        {
            IsCharged = false;
            _testMark.enabled = false;
        }
    }
}