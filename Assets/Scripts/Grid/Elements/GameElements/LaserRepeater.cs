namespace Grid
{
    public class LaserRepeater : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.LaserRepeater;
        public override IElementLogic ElementLogic { get; set; }
    }
}