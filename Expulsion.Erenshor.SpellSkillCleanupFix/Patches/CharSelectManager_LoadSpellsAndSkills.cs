using System.Linq;
using HarmonyLib;

namespace Expulsion.Erenshor.SpellSkillCleanupFix.Patches
{
    [HarmonyPatch(typeof(CharSelectManager), "LoadSpellsAndSkills")]
    public class CharSelectManager_LoadSpellsAndSkills
    {
        public static void Prefix(CharSelectManager __instance)
        {
            var spellsToRemove = GameData.CurrentCharacterSlot.CharacterSpells
                .Where(spell => GameData.SpellDatabase.GetSpellByID(spell) == null)
                .ToList();

            foreach (var spell in spellsToRemove)
            {
                GameData.CurrentCharacterSlot.CharacterSpells.Remove(spell);
                Plugin.Log?.LogInfo($"SpellID: {spell} not found, removing from save");
            }

            var skillsToRemove = GameData.CurrentCharacterSlot.CharacterSkills
                .Where(skill => GameData.SkillDatabase.GetSkillByID(skill) == null)
                .ToList();

            foreach (var skill in skillsToRemove)
            {
                GameData.CurrentCharacterSlot.CharacterSkills.Remove(skill);
                Plugin.Log?.LogInfo($"SkillID: {skill} not found, removing from save");
            }
        }
    }
}