using UnityEngine;

namespace Grid
{
    public class GridBuilderForBuild : GridBuilder
    {
        [SerializeField] [Range(1, 8)] private int _rows;
        [SerializeField] [Range(1, 16)] private int _colums;


        private const string GridElementForBuildName = "ElementForBuild";
        private ElementForBuild _elementForBuild;


        public override Element[] BuildGrid(ref GridData gridData)
        {
            _elementForBuild=LoadGridElement(GridElementForBuildName) as ElementForBuild;

            bool isCommonBuild = _rows !=0 && _colums != 0;
            if (isCommonBuild)
            {
                gridData.Columns = _colums;
                gridData.Rows = _rows;
            }
            
            int elementCount=gridData.Columns* gridData.Rows;
            Element[] gridElements = new Element[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                gridElements[i] =   Instantiate(_elementForBuild, transform);
            }
            
            if (!isCommonBuild)
            {
                gridData.InputElementsData(gridElements);
            }
            
            return gridElements;
        }
        
    }
}