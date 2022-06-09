using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Grid.Elements;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LaserVisualization : MonoBehaviour
{
    private const float DefaultLaserLength= 2.5f;
   
   [SerializeField] private LineRenderer _lineRenderer;
   [SerializeField] private LaserThrower _laserThrower;

   
   private void Update()
   {
       HandleLaserVisualization();
   }

   private void HandleLaserVisualization()
   {
       if (_laserThrower.IsTurnOn)
       {
           _lineRenderer.SetPosition(0, _laserThrower.ShootPoint.position);
           if (_laserThrower.HitInfo)
           {
               _lineRenderer.SetPosition(1, _laserThrower.HitInfo.point);
           }
           else
           {
               _lineRenderer.SetPosition(1,
                   (_laserThrower.ShootPoint.right * DefaultLaserLength + _laserThrower.ShootPoint.position));
           }
       }
       else
       {
           _lineRenderer.SetPosition(0, _laserThrower.ShootPoint.position);
           _lineRenderer.SetPosition(1, _laserThrower.ShootPoint.position);
       }
   }
}
