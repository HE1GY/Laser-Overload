#region

using UnityEngine;

#endregion

namespace Grid
{
    public class GridBuilderForBuild : GridBuilder
    {
        private const string GridElementForBuildName = "ElementForBuild";
        [SerializeField] [Range(1, 8)] private int _rows;
        [SerializeField] [Range(1, 16)] private int _colums;
        private ElementForBuild _elementForBuild;


        public override Element[] BuildGrid(ref GridData gridData)
        {
            _elementForBuild = LoadGridElement(GridElementForBuildName) as ElementForBuild;

            var isCommonBuild = _rows != 0 && _colums != 0;
            if (isCommonBuild)
            {
                gridData.Columns = _colums;
                gridData.Rows = _rows;
            }

            var elementCount = gridData.Columns * gridData.Rows;
            var gridElements = new Element[elementCount];
            for (var i = 0; i < elementCount; i++) gridElements[i] = Instantiate(_elementForBuild, transform);

            if (!isCommonBuild) gridData.InputElementsData(gridElements);

            return gridElements;
        }
    }
}