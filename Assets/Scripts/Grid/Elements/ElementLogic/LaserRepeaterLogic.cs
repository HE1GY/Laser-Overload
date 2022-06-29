#region

using UnityEngine.EventSystems;

#endregion

public class LaserRepeaterLogic : LaserLogic, IRepeater
{
    public void OnEnable()
    {
        IRepeater.Turned += OnClick;
    }

    public void OnDisable()
    {
        IRepeater.Turned -= OnClick;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        IRepeater.Turn();
    }
}