using RimWorld;
using Verse;

namespace LingGame;

public class Comp_SelfDamage : ThingComp
{
    private int tick;

    public override void CompTick()
    {
        tick++;
        if (tick < 5000)
        {
            return;
        }

        parent.TakeDamage(new DamageInfo(DamageDefOf.Cut, 1f, 2f));
        tick = 0;
    }
}