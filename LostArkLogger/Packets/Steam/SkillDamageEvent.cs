using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            CurHp = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
            MaxHp = reader.ReadPackedInt();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            Modifier = reader.ReadByte();
            Damage = reader.ReadPackedInt();
        }
    }
}
