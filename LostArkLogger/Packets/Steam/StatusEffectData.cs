using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            s64_0 = reader.ReadSimpleInt();
            SkillLevel = reader.ReadByte();
            StatusEffectId = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            InstanceId = reader.ReadUInt64();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                s64_1 = reader.ReadUInt64();
            EffectInstanceId = reader.ReadUInt32();
        }
    }
}
