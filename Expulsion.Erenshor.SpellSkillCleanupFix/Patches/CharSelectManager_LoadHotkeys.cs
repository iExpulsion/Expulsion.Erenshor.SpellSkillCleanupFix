using HarmonyLib;

namespace Expulsion.Erenshor.SpellSkillCleanupFix.Patches
{
    [HarmonyPatch(typeof(CharSelectManager), "LoadHotkeys")]
    public class CharSelectManager_LoadHotkeys
    {
        public static void Prefix(CharSelectManager __instance)
        {
            for (var i = 0; i < GameData.CurrentCharacterSlot.HKSpells.Length; i++)
            {
                var spellId = GameData.CurrentCharacterSlot.HKSpells[i];

                if (string.IsNullOrEmpty(spellId)) continue;
                if (GameData.SpellDatabase.GetSpellByID(spellId) != null) continue;

                GameData.CurrentCharacterSlot.HKSpells[i] = "";
                Plugin.Log?.LogInfo($"SpellID: {spellId} not found, removing from hotkeys");
            }

            for (var i = 0; i < GameData.CurrentCharacterSlot.HKSkills.Length; i++)
            {
                var skillId = GameData.CurrentCharacterSlot.HKSkills[i];

                if (string.IsNullOrEmpty(skillId)) continue;
                if (GameData.SkillDatabase.GetSkillByID(skillId) != null) continue;

                GameData.CurrentCharacterSlot.HKSkills[i] = "";
                Plugin.Log?.LogInfo($"SkillID: {skillId} not found, removing from hotkeys");
            }
        }
    }
}