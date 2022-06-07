using UnityEngine;

namespace Grid.Elements
{
    public class LaserThrower:MonoBehaviour
    {
        [SerializeField] private Transform _shootPoints;
        [SerializeField]private bool _isThrowingLaser;//

        public bool IsThrowingLaser
        {
            get => _isThrowingLaser;
            set => _isThrowingLaser=value;
        }

        public Transform ShootPoint => _shootPoints;
        public RaycastHit2D HitInfo=>_raycastHit2D;
        
        
        private LaserReceiver _connectedConsumer;
        private Collider2D _connectedPort;
        private RaycastHit2D _raycastHit2D;

        
        private void Update()
        {
            if (_isThrowingLaser)
            {
                ThrowLaser();
            }
        }
        
        private void ThrowLaser()
        {
            _raycastHit2D = Physics2D.Raycast(_shootPoints.position, _shootPoints.right);
            
            Debug.DrawRay(_shootPoints.position,_shootPoints.right*100,Color.red);//
            
            if (_raycastHit2D && _raycastHit2D.collider.gameObject.TryGetComponent(out LaserReceiver laserReceiver))
            {
                if (laserReceiver != _connectedConsumer)
                {
                    _connectedConsumer?.Disconnect(_connectedPort);
                    bool connect=laserReceiver.TryConnect(_raycastHit2D.collider);
                    if (connect)
                    {
                        _connectedPort = _raycastHit2D.collider;
                        _connectedConsumer = laserReceiver;
                    }
                }
            }
            else
            {
                StopThrowing();
            }
        }


        public void StopThrowing()
        {
            if(_connectedConsumer)
            {
                _connectedConsumer.Disconnect(_connectedPort);
                _connectedConsumer = null;
            }
            _isThrowingLaser = IsThrowingLaser;
        }
        
    }
}