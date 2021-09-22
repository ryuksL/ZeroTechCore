using System.Collections.Generic;
using RimWorld;
using Verse;

namespace LingGame
{
    public class StockGenerator_BuyAnything : StockGenerator
    {
        public override IEnumerable<Thing> GenerateThings(int forTile, Faction faction = null)
        {
            yield break;
        }

        public override bool HandlesThingDef(ThingDef thingDef)
        {
            return thingDef.BaseMarketValue != 0f;
        }
    }
}