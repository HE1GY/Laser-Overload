namespace Grid
{
    public class DirectionSwitcherRepeater : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.DirectionSwitcherRepeater;
        public override IElementLogic ElementLogic { get; set; }
    }
}