using System;

namespace BlockEditor
{
    public enum BlockChildEnum
    {
        JumpPad,
        Blower
    }
    
    public static class BlockChild
    {
        public static string GetTag(this BlockChildEnum child)
        {
            return child switch
            {
                BlockChildEnum.JumpPad => "JumpPad",
                BlockChildEnum.Blower => "Blower",
                _ => throw new ArgumentOutOfRangeException(nameof(child), child, null)
            };
        }
    }
}