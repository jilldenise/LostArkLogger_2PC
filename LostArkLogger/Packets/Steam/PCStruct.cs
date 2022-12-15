using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            b_1 = reader.ReadByte();
            Name = reader.ReadString();
            b_2 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            str_0 = reader.ReadString();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u16_1 = reader.ReadUInt16();
            b_3 = reader.ReadByte();
            b_12 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(25);
            EquippedItems = reader.ReadList<ItemInfo>();
            PlayerId = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(5);
            PartyId = reader.ReadUInt64();
            u32_3 = reader.ReadUInt32();
            b_6 = reader.ReadByte();
            u32list_0 = reader.ReadList<UInt32>(4);
            b_7 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_10 = reader.ReadByte();
            b_11 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            statPair = reader.Read<StatPair>();
            u32_7 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            u32_6 = reader.ReadUInt32();
            b_9 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u16_3 = reader.ReadUInt16();
            GearLevel = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
        }
    }
}
