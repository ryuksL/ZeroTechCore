using UnityEngine;
using Verse;

namespace LingGame;

[StaticConstructorOnStartup]
public static class ZeroTechCoreUI
{
    public static Texture2D OverLock = ContentFinder<Texture2D>.Get("LingUI/Overclocking");
}