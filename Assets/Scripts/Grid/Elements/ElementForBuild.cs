using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Grid
{
    public class ElementForBuild : Element, IPointerDownHandler
    {
        [SerializeField] private Sprite _laser;
        [SerializeField] private Sprite _battery;
        [SerializeField] private Sprite _platformTriangle90;
        [SerializeField] private Sprite _platformStick90;
        [SerializeField] private Sprite _empty;
        [SerializeField] private Sprite _laser3;
        [SerializeField] private Sprite _block;
        [SerializeField] private Sprite _star;
        

        [Space(10)] [SerializeField] private Image _image;

        private const int RotationStep = 90;
        private ElementType _elementType;

        public override ElementType ElementType
        {
            get => _elementType;
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
                case ElementType.PlatformTriangle90:
                    _image.sprite = _platformTriangle90;
                    break;
                case ElementType.Laser3:
                    _image.sprite = _laser3;
                    break;
                case ElementType.PlatformStick90:
                    _image.sprite = _platformStick90;
                    break;
                case ElementType.Block:
                    _image.sprite = _block;
                    break;
                case ElementType.Star:
                    _image.sprite = _star;
                    break;
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetMouseButton(0))
            {
                Selection.activeObject = gameObject;
            }
            else
            {
                ElementType = ElementType.Empty;
            }
        }
    }
}