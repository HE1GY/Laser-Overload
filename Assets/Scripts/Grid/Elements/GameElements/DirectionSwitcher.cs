namespace Grid
{
    public class DirectionSwitcher : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.DirectionSwitcher;
        public override IElementLogic ElementLogic { get; set; }
    }
}