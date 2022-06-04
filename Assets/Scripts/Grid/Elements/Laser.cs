using UnityEngine;

class Laser : LaserInteractor
{
    public override ElementType ElementType { get; protected set; } = ElementType.Laser;


    private void Start()
    {
        SetupLaserRelay(isAllLaserActive: true);
    }
    
}