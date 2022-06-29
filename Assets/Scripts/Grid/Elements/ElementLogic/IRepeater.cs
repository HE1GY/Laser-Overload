#region

using System;

#endregion

public interface IRepeater : IElementLogic
{
    public static event Action Turned;

    public static void Turn()
    {
        Turned?.Invoke();
    }
}