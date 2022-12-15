using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            s64_0 = reader.ReadSimpleInt();
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            EffectInstanceId = reader.ReadUInt32();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                s64_1 = reader.ReadUInt64();
            StatusEffectId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            InstanceId = reader.ReadUInt64();
        }
    }
}
