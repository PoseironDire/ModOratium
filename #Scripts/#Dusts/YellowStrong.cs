using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Dusts
{
    public class YellowStrong : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.scale *= 1.5f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.92f;
            float light = 0.55f * dust.scale;
            Lighting.AddLight(dust.position, 1, 1, 0);
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}