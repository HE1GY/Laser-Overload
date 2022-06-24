#region

#endregion

namespace Grid
{
    public class Teleport : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.Teleport;
        public override IElementLogic ElementLogic { get; set; }
    }
}