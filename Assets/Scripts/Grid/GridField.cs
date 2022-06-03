using UnityEngine;

public class GridField : MonoBehaviour
{
    [SerializeField] private GridHolder[] _gridHolders;
    private GridData _gridData;
    
    public GridData GetData()
    {
        _gridData.ExtractHoldersData(_gridHolders); 
        return _gridData;
    }

    public void SetData(GridData gridData)
    {
        _gridData = gridData;
        _gridData.InputHoldersData(_gridHolders);
    }

    public void Clean()
    {
        _gridData.ResetHoldersData(_gridHolders);
    }
}