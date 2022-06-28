namespace Grid
{
    public class Laser3Repeater : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.Laser3Repeater;
        public override IElementLogic ElementLogic { get; set; }
    }
}