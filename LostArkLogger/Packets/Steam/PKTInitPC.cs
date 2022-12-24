using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(25);
            u16_0 = reader.ReadUInt16();
            u32_0 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            u32_2 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            reader.Skip(66);
            Level = reader.ReadUInt16();
            reader.Skip(44);
            statPair = reader.Read<StatPair>();
            u32_3 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            u32_4 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_4 = reader.ReadByte();
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            u64_1 = reader.ReadUInt64();
            u32_5 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            u16_4 = reader.ReadUInt16();
            Name = reader.ReadString();
            b_10 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_12 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u32_1 = reader.ReadUInt32();
            u32_9 = reader.ReadUInt32();
            b_13 = reader.ReadByte();
            u64_2 = reader.ReadUInt64();
            CharacterId = reader.ReadUInt64();
            bytearraylist_1 = reader.ReadList<Byte[]>(7);
            b_14 = reader.ReadByte();
            b_15 = reader.ReadByte();
            u32_10 = reader.ReadUInt32();
            bytearraylist_1 = reader.ReadList<Byte[]>(17);
            u64_3 = reader.ReadUInt64();
            b_16 = reader.ReadByte();
            b_17 = reader.ReadByte();
            u32_11 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            b_18 = reader.ReadByte();
            bytearraylist_2 = reader.ReadList<Byte[]>(57);
            bytearray_1 = reader.ReadBytes(35);
            b_19 = reader.ReadByte();
            b_20 = reader.ReadByte();
            u32_12 = reader.ReadUInt32();
        }
    }
}
