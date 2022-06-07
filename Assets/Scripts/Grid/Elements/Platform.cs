using UnityEngine.EventSystems;

class Platform : Element,IPointerDownHandler
{
    public override ElementType ElementType { get;  set; } = ElementType.Platform;
    public void OnPointerDown(PointerEventData eventData)
    {
        StartRotation -= 90;
    }
}