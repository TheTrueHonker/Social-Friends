//using RimWorld;
//using Verse;
//using HarmonyLib;
//using Socialfriends.Misc;
//using UnityEngine;

//namespace Socialfriends.Patches
//{
//    [HarmonyPatch]
//    static class JobDriver_StandAndBeSociallyActive_Patch
//    {
//        [HarmonyPatch(typeof(JobDriver_StandAndBeSociallyActive), nameof(JobDriver_StandAndBeSociallyActive.FindClosePawn))]
//        [HarmonyPostfix]
//        static void FindClosePawn_Postfix(ref Pawn __result, ref Pawn ___pawn)
//        {
//            IntVec3 position = ___pawn.Position;
//            Map map = ___pawn.Map;
//            for (int i = 0; i < 24; i++)
//            {
//                IntVec3 intVec = position + GenRadial.RadialPattern[i];
//                if (intVec.InBounds(map))
//                {
//                    Pawn otherPawn = (Pawn) intVec.GetThingList(map).Find((Thing x) => x is Pawn);
//                    var opinion = ___pawn.relations.OpinionOf(otherPawn);
//                    var mappedOpinion = NumberMapper.Map(opinion, -100, 100, 0.1f, 0.9f);
//                    var decision = Random.Range(0f, 1f);
//                    Log.Message($"[Social Friends] otherPawn: {otherPawn.Name}, opinion: {opinion}, mappedOpinion: {mappedOpinion}, decision: {decision}");

//                    if (otherPawn != null && otherPawn != ___pawn && decision < opinion && GenSight.LineOfSight(position, intVec, map))
//                    {
//                        Log.Message($"[Social Friends] Being now social with {otherPawn.Name}");
//                        __result = otherPawn;
//                    }
//                }
//            }
//            __result = null;
//        }
//    }
//}
