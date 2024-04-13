using UnityEngine;

namespace Utils
{
    public static class LayerExtensions
    {
        public static bool CheckLayer(this LayerMask original, int toCheck)
        {
            return (original.value & (1 << toCheck)) > 0;
        }
    }
}