namespace Grid
{
    public class Empty : Element
    {
        public override ElementType ElementType { get; set; }
        public override IElementLogic ElementLogic { get; set; }
    }
}