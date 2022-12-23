using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            reader.Skip(9);
            OwnerId = reader.ReadUInt64();
            reader.Skip(22);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
