using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitPC29
    {
        public void SteamDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            p64_0 = reader.ReadPackedInt();
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            p64_1 = reader.ReadPackedInt();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
        }
    }
}
