using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace LingGame;

public class Comp_TurnRund : ThingComp
{
    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
        yield return new Command_Action
        {
            action = delegate
            {
                var position = parent.Position;
                var map = parent.Map;
                parent.Destroy();
                var unused = new Random();
                GenSpawn.Spawn(ThingMaker.MakeThing(ZeroTechDefOf.MechSerumHealer), position, map);
            },
            defaultLabel = "LingXCG_Change".Translate(),
            defaultDesc = "ChangeTheItemToXXXorAAA".Translate(),
            icon = TexCommand.Attack
        };
    }
}