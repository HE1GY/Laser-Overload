#region

#endregion

public class Battery : Element
{
    public override ElementType ElementType { get; set; } = ElementType.Battery;
    public override IElementLogic ElementLogic { get; set; }
}