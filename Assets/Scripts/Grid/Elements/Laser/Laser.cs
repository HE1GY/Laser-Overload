#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;

#endregion

namespace Grid
{
    public class Laser : Element
    {
        [SerializeField] private LaserThrower _LaserThrower;
        public override ElementType ElementType { get; set; } = ElementType.Laser;


        private void Start()
        {
            _LaserThrower.CallDrawing();
        }


        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _LaserThrower.CallDrawing();
            _LaserThrower.ResetConsumer();
        }
    }
}