

using UnityEngine;
using Verse;

namespace Socialfriends.Misc
{
    static internal class NumberMapper
    {
        public static float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            if (fromMin == fromMax)
            {
                Log.Error("[Social Friends] fromMin and fromMax cannot be the same value.");
                return toMin; // Default to the minimum of the target range
            }

            // Ensure the input value is clamped to the source range
            value = Mathf.Clamp(value, fromMin, fromMax);

            // Normalize the input value to a 0-1 range using InverseLerp
            float t = Mathf.InverseLerp(fromMin, fromMax, value);
            // Map the normalized value to the target range using Lerp
            return Mathf.Lerp(toMin, toMax, t);
        }
    }
}
