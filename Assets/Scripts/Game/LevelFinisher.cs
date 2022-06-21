#region

using System;
using System.Linq;

#endregion

public class LevelFinisher
{
    private readonly ILevelCheckPoint[] _levelCheckPoints; //TODO


    public LevelFinisher(ILevelCheckPoint[] levelCheckPoints)
    {
        _levelCheckPoints = levelCheckPoints;
        foreach (var levelCheckPoint in levelCheckPoints) levelCheckPoint.Passed += CheckLevelState;
    }

    public event Action LevelCompleted;

    private void CheckLevelState()
    {
        if (_levelCheckPoints.All(bl => bl.IsPassed)) LevelCompleted?.Invoke();
    }
}