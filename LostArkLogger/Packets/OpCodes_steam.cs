using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 11820,
        PKTCounterAttackNotify = 51601,
        PKTDeathNotify = 41723,
        PKTInitEnv = 44803,
        PKTInitPC = 14834,
        PKTNewNpc = 39325,
        PKTNewNpcSummon = 11734,
        PKTNewPC = 28590,
        PKTNewProjectile = 17144,
        PKTPartyStatusEffectAddNotify = 40990,
        PKTPartyStatusEffectRemoveNotify = 16272,
        PKTRaidBossKillNotify = 25754,
        PKTRaidResult = 18106,
        PKTRemoveObject = 839,
        PKTSkillDamageAbnormalMoveNotify = 13919,
        PKTSkillDamageNotify = 22707,
        PKTSkillStageNotify = 58262,
        PKTSkillStartNotify = 15058,
        PKTStatChangeOriginNotify = 36350,
        PKTStatusEffectAddNotify = 58877,
        PKTStatusEffectRemoveNotify = 1763,
        PKTTriggerBossBattleStatus = 27798,
        PKTTriggerStartNotify = 42482
    }
}
