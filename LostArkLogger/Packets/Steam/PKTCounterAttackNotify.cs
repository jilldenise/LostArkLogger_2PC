using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public void SteamDecode(BitReader reader)
        {
            reader.Skip(2);
            TargetId = reader.ReadUInt64();
            Type = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
        }
    }
}
