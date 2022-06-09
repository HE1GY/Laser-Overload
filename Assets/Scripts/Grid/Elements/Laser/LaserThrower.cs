using UnityEngine;

namespace Grid.Elements
{
    public class LaserThrower:MonoBehaviour
    {
        [SerializeField] private Transform _shootPoints;
        [SerializeField]private bool _isTurnOn;


        public int ReceivedEnergy { get; set; }
        
        public bool IsTurnOn
        {
            get => ReceivedEnergy>0||_isTurnOn;
        }

        public Transform ShootPoint => _shootPoints;
        public RaycastHit2D HitInfo=>_raycastHit2D;
        
        
        private LaserReceiver _connectedConsumer;
        private Collider2D _connectedPort;
        private RaycastHit2D _raycastHit2D;

        
        private void Update()
        {
            if (IsTurnOn)
            {
                ThrowLaser();
            }
        }
        
        private void ThrowLaser()
        {
            _raycastHit2D = Physics2D.Raycast(_shootPoints.position, _shootPoints.right);

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
                Debug.DrawRay(_shootPoints.position,_shootPoints.right*_raycastHit2D.distance,Color.black);//
                
            }
            else
            {
                ResetConsumer();
            }
        }


        public void ResetConsumer()
        {
            if(_connectedConsumer)
            {
                _connectedConsumer.Disconnect(_connectedPort);
                _connectedConsumer = null;
            }
        }
        
        
    }
}