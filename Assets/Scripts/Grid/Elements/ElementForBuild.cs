using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Grid
{
    public class ElementForBuild : Element,IPointerDownHandler
    {
        [SerializeField] private Sprite _laser;
        [SerializeField] private Sprite _battery;
        [SerializeField] private Sprite _platform;
        [SerializeField] private Sprite _empty;
        [SerializeField] private Sprite _laser3;
        [Space(10)]
        [SerializeField]private Image _image;

        private const int RotationStep = 90;
        private ElementType _elementType;

        public override ElementType ElementType
        {
            get=>_elementType;
            set
            {
                _elementType = value;
                OnElementChange();
            }
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
                case ElementType.Platform:
                    _image.sprite = _platform;
                    break;
                case ElementType.Laser3:
                    _image.sprite = _laser3;
                    break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetMouseButton(0))
            {
                Selection.activeObject = gameObject;
            }
            else
            {
                ElementType=ElementType.Empty;
            }
        }
    }
}