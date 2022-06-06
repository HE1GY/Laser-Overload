
public struct GridData
{
    public int Rows;
    public int Columns;
    
    public ElementType[] ElementTypes;
    public int[] StartRotations;
    
    public void ExtractElementsData(Element[] elements)
    {
        ElementTypes = new ElementType[elements.Length];
        StartRotations = new int[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            ElementTypes[i]=elements[i].ElementType;
            StartRotations[i] = elements[i].StartRotation;
        }
    }

    public void InputElementsData(Element[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].ElementType = ElementTypes[i];
            elements[i].StartRotation =(int)StartRotations[i];
        }
    }
  
}