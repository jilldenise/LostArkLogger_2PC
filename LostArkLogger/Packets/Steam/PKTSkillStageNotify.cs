using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            reader.Skip(24);
            SourceId = reader.ReadUInt64();
            reader.Skip(5);
            SkillId = reader.ReadUInt32();
            reader.Skip(11);
            Stage = reader.ReadByte();
            reader.Skip(1);
        }
    }
}
