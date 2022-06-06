using System;
using Grid;
using UnityEngine;
using UnityEngine.UI;

public class GridField : MonoBehaviour
{
    [SerializeField]private GridLayoutGroup _gridLayout;
    
    private GridData _gridData;
    private GridBuilder _gridBuilder;
    private Element[] _gridElements;

    public GridData GetData()
    {
        _gridData.ExtractElementsData(_gridElements); 
        return _gridData;
    }

    public void SetData(GridData gridData)
    {
        _gridData = gridData;
        Build();
    }
    
    public void ChooseBuilder(Type typeOfBuilder)
    {
        Destroy(_gridBuilder);
        _gridBuilder=gameObject.AddComponent(typeOfBuilder) as GridBuilder;
    }

    public void Build()
    {
        DeleteAllElement();
        _gridElements=_gridBuilder.BuildGrid(ref _gridData);
        GridLayoutConficuration();
    }

    private void GridLayoutConficuration()
    {
        _gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayout.constraintCount = _gridData.Columns;
    }

    private void DeleteAllElement()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}