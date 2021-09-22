using RimWorld;

namespace LingGame
{
    public class CompTargetable_PawnHasDeathAcidifier : CompTargetable_SinglePawn
    {
        protected override TargetingParameters GetTargetingParameters()
        {
            return new TargetingParameters
            {
                canTargetPawns = true,
                canTargetBuildings = false,
                validator = x => BaseTargetValidator(x.Thing)
            };
        }
    }
}