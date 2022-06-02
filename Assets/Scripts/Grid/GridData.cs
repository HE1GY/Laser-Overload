public struct GridData
{
    /*public int[] AllRow;
    public int[] AllColumn;*/
    public ElementType[] PartTypes;
    /*public bool[] isActive;*/
    public int[] _startRoataions;
    
    public void ExtractPartsData(GridHolder[] parts)
    {
        /*AllRow = new int[parts.Length];
        AllColumn = new int[parts.Length];*/
        PartTypes = new ElementType[parts.Length];
        /*isActive = new bool[parts.Length];*/
        _startRoataions = new int[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            /*AllRow[i] = parts[i].Row;
            AllColumn[i]=parts[i].Column;*/
            PartTypes[i]=parts[i].elementType;
            /*isActive[i] = parts[i].Active;*/
            _startRoataions[i] = parts[i].SatartRotation;
        }
    }
    
    
}