#region

#endregion

namespace Grid
{
    public class Laser3 : Element
    {
        public override ElementType ElementType { get; set; } = ElementType.Laser3;
        public override IElementLogic ElementLogic { get; set; }
    }
}