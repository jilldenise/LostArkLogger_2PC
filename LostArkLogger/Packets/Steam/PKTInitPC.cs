using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void SteamDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            u32_3 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u32_4 = reader.ReadUInt32();
            bytearray_3 = reader.ReadBytes(35);
            u32_11 = reader.ReadUInt32();
            bytearraylist_1 = reader.ReadList<Byte[]>(17);
            b_0 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            u32_12 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            GearLevel = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            u16_0 = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            b_3 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            u32_6 = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            b_4 = reader.ReadByte();
            b_20 = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(112);
            u64_1 = reader.ReadUInt64();
            u64_2 = reader.ReadUInt64();
            u64_3 = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u32_1 = reader.ReadUInt32();
            u32_7 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u64_4 = reader.ReadUInt64();
            b_12 = reader.ReadByte();
            b_13 = reader.ReadByte();
            u32_9 = reader.ReadUInt32();
            b_14 = reader.ReadByte();
            b_15 = reader.ReadByte();
            b_16 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            b_17 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            b_18 = reader.ReadByte();
            u32_10 = reader.ReadUInt32();
            Name = reader.ReadString();
            u16_4 = reader.ReadUInt16();
            b_19 = reader.ReadByte();
            bytearraylist_2 = reader.ReadList<Byte[]>(2);
            reader.Skip(24);
            u16_5 = reader.ReadUInt16();
            reader.Skip(-1);
            bytearraylist_3 = reader.ReadList<Byte[]>(1);
            b_11 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
        }
    }
}
