using Verse;

namespace Socialfriends
{
    [StaticConstructorOnStartup]
    public static class Harmony
    {
        static Harmony()
        {
            HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("TheTrueHonker.SocialFriends");
            harmony.PatchAll();
            Log.Message("[Social Friends] All patches applied");
        }        
    }
}
