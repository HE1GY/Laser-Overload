using System;

public interface ILevelCheckPoint:IElementLogic
{
    public bool IsPassed { get; set; }
    public event Action Passed;
}