#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;

#endregion

namespace Grid
{
    public class Laser : Element, IPointerDownHandler
    {
        [SerializeField] private LaserThrower _LaserThrower;
        public override ElementType ElementType { get; set; } = ElementType.Laser;
        public override IElementLogic ElementLogic { get; set; }


        private void Start()
        {
            _LaserThrower.CallDrawing();
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            StartRotation -= 90;
            _LaserThrower.CallDrawing();
            _LaserThrower.ResetConsumer();
        }
    }
}