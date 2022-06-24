﻿#region

using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

namespace Grid
{
    public class ElementForBuild : Element, IPointerDownHandler
    {
        private const int RotationStep = 90;

        public Sprite _laser;
        public Sprite _battery;
        public Sprite _platformTriangle90;
        public Sprite _platformStick90;
        public Sprite _empty;
        public Sprite _laser3;
        public Sprite _block;
        public Sprite _star;
        public Sprite _teleport;


        [Space(10)] [SerializeField] private Image _image;
        private ElementType _elementType;

        public override IElementLogic ElementLogic { get; set; }

        public override ElementType ElementType
        {
            get => _elementType;
            set
            {
                _elementType = value;
                OnElementChange();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
                Selection.activeObject = gameObject;
            else
                ElementType = ElementType.Empty;
#endif
        }


        public void Turn()
        {
            StartRotation += RotationStep;
        }

        private void OnElementChange()
        {
            switch (ElementType)
            {
                case ElementType.Battery:
                    _image.sprite = _battery;
                    break;
                case ElementType.Empty:
                    _image.sprite = _empty;
                    break;
                case ElementType.Laser:
                    _image.sprite = _laser;
                    break;
                case ElementType.PlatformTriangle90:
                    _image.sprite = _platformTriangle90;
                    break;
                case ElementType.Laser3:
                    _image.sprite = _laser3;
                    break;
                case ElementType.PlatformStick90:
                    _image.sprite = _platformStick90;
                    break;
                case ElementType.Star:
                    _image.sprite = _star;
                    break;
                case ElementType.Block:
                    _image.sprite = _block;
                    break;
                case ElementType.Teleport:
                    _image.sprite = _teleport;
                    break;
            }
        }
    }
}