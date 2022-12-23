using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            StatusEffectIds = reader.ReadList<UInt32>();
        }
    }
}
