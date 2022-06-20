using Grid.Elements;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLogic : EnergyReceiver
{
    [SerializeField] private Image _testMark; //test
    protected override void AfterStartReceiving()
    {
        if (ReceivedEnergy > 0) _testMark.enabled = true;
    }

    protected override void AfterEndReceiving()
    {
        if (ReceivedEnergy == 0) _testMark.enabled = false;
    }
    
    
}