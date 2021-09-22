using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace LingGame
{
    [StaticConstructorOnStartup]
    public class WeatherEvent_LightningStrikeNoFire : WeatherEvent_LightningFlash
    {
        private static readonly Material LightningMat = MatLoader.LoadMat("Weather/LightningBolt");

        private Mesh boltMesh;
        private IntVec3 strikeLoc = IntVec3.Invalid;

        public WeatherEvent_LightningStrikeNoFire(Map map)
            : base(map)
        {
        }

        public WeatherEvent_LightningStrikeNoFire(Map map, IntVec3 forcedStrikeLoc)
            : base(map)
        {
            strikeLoc = forcedStrikeLoc;
        }

        public override void FireEvent()
        {
            base.FireEvent();
            if (!strikeLoc.IsValid)
            {
                strikeLoc = CellFinderLoose.RandomCellWith(sq => sq.Standable(map) && !map.roofGrid.Roofed(sq), map);
            }

            boltMesh = LightningBoltMeshPool.RandomBoltMesh;
            var vector = strikeLoc.ToVector3Shifted();
            for (var i = 0; i < 4; i++)
            {
                FleckMaker.ThrowSmoke(vector, map, 1.5f);
                FleckMaker.ThrowMicroSparks(vector, map);
                FleckMaker.ThrowLightningGlow(vector, map, 1.5f);
            }

            var info = SoundInfo.InMap(new TargetInfo(strikeLoc, map));
            SoundDefOf.Thunder_OnMap.PlayOneShot(info);
        }

        public override void WeatherEventDraw()
        {
            Graphics.DrawMesh(boltMesh, strikeLoc.ToVector3ShiftedWithAltitude(AltitudeLayer.Gas), Quaternion.identity,
                FadedMaterialPool.FadedVersionOf(LightningMat, LightningBrightness), 0);
        }
    }
}