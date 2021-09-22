using Verse;

namespace LingGame
{
    public class LingHealthUnity
    {
        public BodyPartRecord GetBodyPart(Pawn pawn, string bodypartdef)
        {
            foreach (var notMissingPart in pawn.health.hediffSet.GetNotMissingParts())
            {
                if (notMissingPart.def.defName.Contains(bodypartdef))
                {
                    return notMissingPart;
                }
            }

            return null;
        }
    }
}