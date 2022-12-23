using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 44294,
        PKTCounterAttackNotify = 23544,
        PKTDeathNotify = 21940,
        PKTInitEnv = 12201,
        PKTInitPC = 44217,
        PKTNewNpc = 31638,
        PKTNewNpcSummon = 57156,
        PKTNewPC = 13099,
        PKTNewProjectile = 1296,
        PKTPartyStatusEffectAddNotify = 8895,
        PKTPartyStatusEffectRemoveNotify = 13843,
        PKTRaidBossKillNotify = 20140,
        PKTRaidResult = 17609,
        PKTRemoveObject = 39958,
        PKTSkillDamageAbnormalMoveNotify = 29416,
        PKTSkillDamageNotify = 1847,
        PKTSkillStageNotify = 6028,
        PKTSkillStartNotify = 45202,
        PKTStatChangeOriginNotify = 36460,
        PKTStatusEffectAddNotify = 4713,
        PKTStatusEffectRemoveNotify = 55030,
        PKTTriggerBossBattleStatus = 35800,
        PKTTriggerStartNotify = 50016
    }
}
