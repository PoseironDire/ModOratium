using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Dusts
{
    public class GreenSmall : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.3f;
            dust.scale *= 0.9f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, 0f, 0.4f, 0f);
            if (dust.scale < 0.4f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}