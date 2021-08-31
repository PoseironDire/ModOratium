using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Dusts
{
    public class BlueStrong : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.4f;
            dust.scale *= 2.0f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.97f;
            float light = 0.55f * dust.scale;
            Lighting.AddLight(dust.position, 0, 0, 1f);
            if (dust.scale < 0.9f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}