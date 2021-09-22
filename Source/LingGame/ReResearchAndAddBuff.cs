using RimWorld;
using Verse;

namespace LingGame
{
    public class ReResearchAndAddBuff : ResearchMod
    {
        public ResearchProjectDef def;

        public override void Apply()
        {
            Current.Game.GetComponent<GameComponent_ZeroWatchYou>().BlessingLevel++;
            foreach (var map in Find.Maps)
            {
                foreach (var freeColonist in map.mapPawns.FreeColonists)
                {
                    freeColonist.health.AddHediff(HediffDefOf.Anesthetic);
                }
            }

            var amount = Find.ResearchManager.currentProj.baseCost / -0.00825f /
                         Find.Storyteller.difficulty.researchSpeedFactor;
            Find.ResearchManager.ResearchPerformed(amount, null);
        }
    }
}