using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace LingGame
{
    public class Building_GelMaker : Building_Storage
    {
        private float HaveMass;

        private bool OverLock = true;

        public override string GetInspectString()
        {
            var inspectString = base.GetInspectString();
            return string.Concat(new[]
            {
                inspectString,
                "\n",
                "Mass:" + HaveMass + "kg"
            });
        }

        public override void TickRare()
        {
            base.TickRare();
            if (!GetComp<CompPowerTrader>().PowerOn)
            {
                return;
            }

            if (slotGroup.HeldThings.Any())
            {
                var thing = slotGroup.HeldThings.RandomElement();
                if (thing.def == ZeroTechDefOf.ZeroTechGel)
                {
                    thing.Position = InteractionCell;
                }
                else
                {
                    var num = thing.def.BaseMass * thing.stackCount;
                    if (thing is MinifiedThing minifiedThing)
                    {
                        num = minifiedThing.InnerThing.def.BaseMass;
                    }

                    HaveMass += num;
                    thing.Destroy();
                }
            }

            if (!(HaveMass > 1f))
            {
                return;
            }

            if (OverLock)
            {
                var thing2 = ThingMaker.MakeThing(ZeroTechDefOf.ZeroTechGel);
                var num2 = Math.Min(Math.Min(HaveMass, (float)thing2.def.stackLimit / 5), 100f);
                thing2.stackCount = (int)num2 * 5;
                HaveMass -= num2;
                GenSpawn.Spawn(thing2, InteractionCell, Map);
            }
            else if (Rand.Chance(0.01f))
            {
                HaveMass -= 1f;
                var newThing = ThingMaker.MakeThing(ZeroTechDefOf.LingZeroTechPowerCore);
                GenSpawn.Spawn(newThing, InteractionCell, Map);
            }
            else
            {
                var thing3 = ThingMaker.MakeThing(ZeroTechDefOf.ZeroTechGel);
                var num3 = Math.Min(Math.Min(HaveMass, (float)thing3.def.stackLimit / 5), 1f);
                thing3.stackCount = (int)num3 * 5;
                HaveMass -= num3;
                GenSpawn.Spawn(thing3, InteractionCell, Map);
            }
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (var gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }

            yield return new Command_Toggle
            {
                defaultLabel = "Overclocking".Translate(),
                defaultDesc = "OverclockingDesc".Translate(),
                icon = ZeroTechCoreUI.OverLock,
                isActive = () => OverLock,
                toggleAction = delegate { OverLock = !OverLock; }
            };
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref HaveMass, "HaveMass");
            Scribe_Values.Look(ref OverLock, "OverLock");
        }
    }
}