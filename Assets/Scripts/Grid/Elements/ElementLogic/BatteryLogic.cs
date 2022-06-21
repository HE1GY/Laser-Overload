#region

using System;
using Grid.Elements;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class BatteryLogic : EnergyReceiver, ILevelCheckPoint
{
    [SerializeField] private Image _testMark; //test

    public event Action Passed;
    public bool IsPassed { get; set; }


    protected override void AfterStartReceiving()
    {
        if (ReceivedEnergy > 0)
        {
            IsPassed = true;
            _testMark.enabled = true;
            Passed?.Invoke();
        }
    }

    protected override void AfterEndReceiving()
    {
        if (ReceivedEnergy == 0)
        {
            IsPassed = false;
            _testMark.enabled = false;
        }
    }
}