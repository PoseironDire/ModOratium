using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Dusts
{
    public class RedStrong : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.scale *= 1.0f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.94f;
            float light = 0.55f * dust.scale;
            Lighting.AddLight(dust.position, 0.5f, 0, 0);
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}