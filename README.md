# SpellSkillCleanupFix
Prevents errors when loading a save file with removed Spell/Skill IDs.

## Features
- Checks the save file for nonexistance Spells/Skills and removes them before loading the character.

## Installation
- Requires [BepInEx](https://github.com/BepInEx/BepInEx)
- Download `Expulsion.Erenshor.SpellSkillCleanupFix.dll` [Latest Release](https://github.com/iExpulsion/Expulsion.Erenshor.SpellSkillCleanupFix/releases/latest)
- Place the DLL inside your `BepInEx/Plugins` Directory

## Modifications
*Helpful info for determining potential conflicts with other plugins.*
### Prefix Patch
- `CharSelectManager.LoadHotkeys()`
- `CharSelectManager.LoadSpellsAndSkills()`
