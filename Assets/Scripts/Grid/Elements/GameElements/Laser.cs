namespace Grid
{
    public class Laser : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.Laser;
        public override IElementLogic ElementLogic { get; set; }
    }
}