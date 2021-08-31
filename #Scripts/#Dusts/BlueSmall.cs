using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Dusts
{
    public class BlueSmall : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.1f;
            dust.scale *= 1.0f;
            dust.noGravity = false;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, 1, 1, 2);
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(lightColor.R, lightColor.G, lightColor.B, 40);
        }
    }
}