using RimWorld;
using Verse;
using HarmonyLib;
using Socialfriends.Misc;
using UnityEngine;

namespace Socialfriends.Patches
{
    [HarmonyPatch]
    static class Pawn_InteractionsTracker_Patch
    {
        [HarmonyPatch(typeof(Pawn_InteractionsTracker), nameof(Pawn_InteractionsTracker.TryInteractWith))]
        [HarmonyPrefix]
        static bool TryInteractWith(Pawn recipient, Pawn ___pawn)
        {
            if(___pawn == recipient)
                return true;

            var opinion = ___pawn.relations.OpinionOf(recipient);
            var mappedOpinion = NumberMapper.Map(opinion, -100, 100, 0.1f, 0.9f);
            var decision = Random.Range(0f, 1f);
            Log.Message($"[Social Friends] Pawn: {___pawn.Name}, Recipient: {recipient.Name}, opinion: {opinion}, mappedOpinion: {mappedOpinion}, decision: {decision}");

            if (decision > mappedOpinion)
            {
                return false;
            }

            Log.Message($"[Social Friends] Being now trying to be social with {recipient.Name}");
            return true;
        }
    }
}
