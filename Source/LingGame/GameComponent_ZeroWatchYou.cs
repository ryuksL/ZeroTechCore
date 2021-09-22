using RimWorld;
using Verse;

namespace LingGame
{
    public class GameComponent_ZeroWatchYou : GameComponent
    {
        public int BlessingLevel;

        public GameComponent_ZeroWatchYou(Game game)
        {
        }

        public override void StartedNewGame()
        {
            base.StartedNewGame();
            Messages.Message("I watching you...", MessageTypeDefOf.NegativeEvent);
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref BlessingLevel, "BlessingLevel");
        }
    }
}