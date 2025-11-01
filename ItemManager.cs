using Noname.Worldless.Navigation;
using UnityEngine;

namespace WorldlessArchipelago;
public class ItemManager
{
    internal static bool noclipping { get; private set; }
    internal static void Set(Skill skill, bool state)
    {
        SkillsProgression skillsProgression = GameObject.Find("NavigationSystem(Clone)").GetComponent<NavigationProgression>().skills;
        skillsProgression.saveData.unlockedSkills[skill] = state;
        skillsProgression.SaveRequest();
    }
    internal static bool Get(Skill skill)
    {
        SkillsProgression skillsProgression = GameObject.Find("NavigationSystem(Clone)").GetComponent<NavigationProgression>().skills;
        return skillsProgression.saveData.unlockedSkills[skill];
    }

}