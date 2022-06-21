using System;
using System.Linq;

public class LevelCheckPoint
{
    public event Action LevelCompleted;
    private BatteryLogic[] _batteryLogics;


    public LevelCheckPoint(BatteryLogic[] batteryLogics)
    {
        _batteryLogics = batteryLogics;
        foreach (BatteryLogic batteryLogic in batteryLogics)
        {
            batteryLogic.Chargered += CheckLevelState;
        }
    }

    private void CheckLevelState()
    {
        if (_batteryLogics.All(bl => bl.IsCharged))
        {
            LevelCompleted?.Invoke();
        }
    }
    
    
}