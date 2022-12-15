using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            reader.Skip(7);
            OwnerId = reader.ReadUInt64();
            reader.Skip(24);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
