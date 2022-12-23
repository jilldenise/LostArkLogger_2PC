using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            str_0 = reader.ReadString();
            u16_0 = reader.ReadUInt16();
            b_1 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                bytearray_1 = reader.ReadBytes(12);
            b_2 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_3 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            GearLevel = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            Level = reader.ReadUInt16();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            b_10 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            itemInfos = reader.ReadList<ItemInfo>();
            u32_3 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            u32list_0 = reader.ReadList<UInt32>(4);
            ClassId = reader.ReadUInt16();
            u32_4 = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(5);
            Name = reader.ReadString();
            u32_5 = reader.ReadUInt32();
            u32_6 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            bytearray_0 = reader.ReadBytes(25);
            b_12 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            u32_7 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            PlayerId = reader.ReadUInt64();
        }
    }
}
