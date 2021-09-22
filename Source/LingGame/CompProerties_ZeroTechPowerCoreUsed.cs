using RimWorld;
using Verse;

namespace LingGame
{
    public class CompProerties_ZeroTechPowerCoreUsed : CompUseEffect
    {
        public override void DoEffect(Pawn usedBy)
        {
            var array = new[]
            {
                usedBy.skills.skills.RandomElement(),
                usedBy.skills.skills.RandomElement(),
                usedBy.skills.skills.RandomElement()
            };
            foreach (var skillRecord in array)
            {
                if (skillRecord.levelInt.Inbounds(0, 19))
                {
                    skillRecord.Level++;
                }
            }

            Messages.Message(
                "UseZerotechPowerCore".Translate(usedBy.Name.ToStringShort, array[0].def.LabelCap,
                    array[1].def.LabelCap, array[2].def.LabelCap), MessageTypeDefOf.NegativeEvent);
        }
    }
}