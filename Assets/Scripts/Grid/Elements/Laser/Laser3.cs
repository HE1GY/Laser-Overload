using UnityEngine.EventSystems;

namespace Grid
{
    public class Laser3:Element,IPointerDownHandler
    {
        public override ElementType ElementType { get; set; } = ElementType.Laser3;
        public void OnPointerDown(PointerEventData eventData)
        {
            StartRotation -= 90;
        }
    }
}