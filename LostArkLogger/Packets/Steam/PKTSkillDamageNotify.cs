using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            SkillEffectId = reader.ReadUInt32();
        }
    }
}
