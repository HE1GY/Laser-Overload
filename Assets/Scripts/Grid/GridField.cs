#region

using System;
using Grid;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class GridField : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    private GridBuilder _gridBuilder;

    private GridData _gridData;
    private Element[] _gridElements;
    public event Action<Element[]> GridBuilt;

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
        _gridBuilder = gameObject.AddComponent(typeOfBuilder) as GridBuilder;
    }


    public void Build()
    {
        DeleteAllElement();
        if (!_gridBuilder)
        {
            ChooseBuilder(typeof(GridBuilderForGame));
        }
        _gridElements = _gridBuilder.BuildGrid(ref _gridData);
        GridLayoutConfiguration();
        GridBuilt?.Invoke(_gridElements);
    }

    private void GridLayoutConfiguration()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _gridData.Columns;
    }

    private void DeleteAllElement()
    {
        for (var i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }
}