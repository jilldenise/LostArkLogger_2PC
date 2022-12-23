using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            PlayerIdOnRefresh = reader.ReadUInt64();
            PartyId = reader.ReadUInt64();
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
        }
    }
}
