#region

using UnityEngine.EventSystems;

#endregion

public class Battery : Element
{
    public override ElementType ElementType { get; set; } = ElementType.Battery;

    public override void OnPointerDown(PointerEventData eventData)
    {
        //TODO 
    }
}