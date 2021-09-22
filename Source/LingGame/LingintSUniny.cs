using System;

namespace LingGame
{
    public static class LingintSUniny
    {
        public static bool Inbounds(this int i, int min, int max)
        {
            return i >= min && i <= max;
        }

        public static int Abs(this int i)
        {
            return Math.Abs(i);
        }
    }
}