using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Grid.Elements;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LaserVisualization : MonoBehaviour
{
   [SerializeField] private float _defaultLaserLength;
   
   [SerializeField] private LineRenderer _lineRenderer;
   [SerializeField] private LaserThrower _laserThrower;

   
   private void Update()
   {
       HandleLaserVisualization();
   }

   private void HandleLaserVisualization()
   {
       if (_laserThrower.IsThrowingLaser)
       {
           _lineRenderer.SetPosition(0, _laserThrower.ShootPoint.position);
           if (_laserThrower.HitInfo)
           {
               _lineRenderer.SetPosition(1, _laserThrower.HitInfo.point);
           }
           else
           {
               _lineRenderer.SetPosition(1,
                   (_laserThrower.ShootPoint.right * _defaultLaserLength + _laserThrower.ShootPoint.position));
           }
       }
       else
       {
           _lineRenderer.SetPosition(0, _laserThrower.ShootPoint.position);
           _lineRenderer.SetPosition(1, _laserThrower.ShootPoint.position);
       }
   }
}
