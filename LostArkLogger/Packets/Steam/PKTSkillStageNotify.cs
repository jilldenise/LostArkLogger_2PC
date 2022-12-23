using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            reader.Skip(29);
            SourceId = reader.ReadUInt64();
            reader.Skip(4);
            Stage = reader.ReadByte();
            reader.Skip(8);
            SkillId = reader.ReadUInt32();
        }
    }
}
