﻿using UnityEngine.EventSystems;

namespace Grid
{
    public class Laser:Element,IPointerDownHandler
    {
        public override ElementType ElementType { get; set; } = ElementType.Laser;
        public void OnPointerDown(PointerEventData eventData)
        {
            StartRotation -= 90;
        }
    }
}