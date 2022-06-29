namespace Grid
{
    public class Block : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.Block;
        public override IElementLogic ElementLogic { get; set; }
    }
}