using System.Collections.Generic;
using Verse;

namespace LingGame;

public class CrystalPill : Building
{
    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        yield return new Command_Action
        {
            defaultLabel = "".Translate(),
            defaultDesc = "".Translate(),
            action = delegate { }
        };
    }
}