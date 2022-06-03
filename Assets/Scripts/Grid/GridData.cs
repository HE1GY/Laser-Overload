
public struct GridData
{
    public ElementType[] ElementTypes;
    public int[] StartRotations;
    
    public void ExtractHoldersData(GridHolder[] gridHolders)
    {
        ElementTypes = new ElementType[gridHolders.Length];
        StartRotations = new int[gridHolders.Length];

        for (int i = 0; i < gridHolders.Length; i++)
        {
            ElementTypes[i]=gridHolders[i].SelectedElementType;
            StartRotations[i] = gridHolders[i].StartRotation;
        }
    }

    public void InputHoldersData(GridHolder[] gridHolders)
    {
        for (int i = 0; i < gridHolders.Length; i++)
        {
            gridHolders[i].SelectedElementType = ElementTypes[i];
            gridHolders[i].StartRotation =(int)StartRotations[i];
        }
    }
    public void ResetHoldersData(GridHolder[] gridHolders)
    {
        ElementTypes = new ElementType[gridHolders.Length];
        StartRotations = new int[gridHolders.Length];
        InputHoldersData(gridHolders);
    }
}