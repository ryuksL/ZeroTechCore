using Verse;

namespace LingGame
{
    public class ReResearchNothig : ResearchMod
    {
        public ResearchProjectDef def;

        public override void Apply()
        {
            var currentProj = Find.ResearchManager.currentProj;
            foreach (var allDef in DefDatabase<ResearchProjectDef>.AllDefs)
            {
                if (allDef.tab.defName != "ZeroTech" || !allDef.IsFinished)
                {
                    continue;
                }

                Log.Message("you lose... " + allDef.LabelCap);
                Find.ResearchManager.currentProj = allDef;
                var amount = Find.ResearchManager.currentProj.baseCost / -0.00825f /
                             Find.Storyteller.difficulty.researchSpeedFactor;
                Find.ResearchManager.ResearchPerformed(amount, null);
            }

            Find.ResearchManager.currentProj = currentProj;
        }
    }
}