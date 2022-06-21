#region

using UnityEngine.EventSystems;

#endregion

public class Battery : Element
{
    public BatteryLogic BatteryLogic;
    public override ElementType ElementType { get; set; } = ElementType.Battery;

    public override void OnPointerDown(PointerEventData eventData)
    {
        //TODO 
    }
}