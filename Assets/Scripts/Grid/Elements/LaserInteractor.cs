using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  abstract class  LaserInteractor : Element
{
    
    [SerializeField]private LaserRelаyData[] _laserRelаyDatas;
    private LaserRelay[] _laserRelays;

    private void Start()
    {
        SetupLaserRelay();
    }

    private void Update()
    {
        HandleAllLaserThrowing();
    }

    public bool TryDoRayInteraction(Collider2D collider2D)
    {
        List<bool> receiversReplys=new List<bool>();
        foreach (var laserRelay in _laserRelays)
        {
            receiversReplys.Add(laserRelay.TryReceived(collider2D));
        }
        return receiversReplys.Any(r => r);
    }

    protected void SetupLaserRelay(bool isAllLaserActive=false)
    {
        _laserRelays = new LaserRelay[_laserRelаyDatas.Length];
        for (int i = 0; i < _laserRelаyDatas.Length; i++)
        {
            _laserRelays[i] = new LaserRelay(_laserRelаyDatas[i],isAllLaserActive);
        }
    }

    private void HandleAllLaserThrowing()
    {
        foreach (var laserRelay in _laserRelays)
        {
            laserRelay.HandleLaserThrowing();
        }
    }
}

