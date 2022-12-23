using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            b_1 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            str_0 = reader.ReadString();
            itemInfos = reader.ReadList<ItemInfo>();
            b_0 = reader.ReadByte();
            b_2 = reader.ReadByte();
        }
    }
}
