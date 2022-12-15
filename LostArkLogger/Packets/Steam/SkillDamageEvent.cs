using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            Damage = reader.ReadPackedInt();
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            CurHp = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
            MaxHp = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
        }
    }
}
