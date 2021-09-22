using RimWorld;

namespace LingGame
{
    public class PowerBelt : Apparel
    {
        public float Power = 100f;

        public int ReNeedTime;

        public float PowerReS => this.GetStatValue(StatDefOf.EnergyShieldRechargeRate);

        public float PowerMas => this.GetStatValue(StatDefOf.EnergyShieldEnergyMax);

        public float ReMeedTimemas => this.GetStatValue(StatDefOf.SmokepopBeltRadius);

        private bool CanReP => true;

        public void UsePower(float oe)
        {
            Power -= oe;
        }

        public void UsePower(int BaiFenBi)
        {
            Power -= PowerMas / (BaiFenBi / 100f);
        }

        public void UsePower()
        {
            Power = 0f;
        }

        public override void Tick()
        {
            base.Tick();
            if (ReNeedTime > 0)
            {
                ReNeedTime--;
                return;
            }

            if (Power <= 0f)
            {
                Power = 0f;
            }

            Power += PowerReS;
            if (Power >= PowerMas)
            {
                Power = PowerMas;
            }
        }
    }
}