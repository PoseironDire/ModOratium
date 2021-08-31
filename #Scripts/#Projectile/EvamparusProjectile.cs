using ModOratium.Items.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Projectiles
{
    public class EvamparusProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evamparus Projectile");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.penetrate = 4;
            projectile.timeLeft = 300;
            projectile.extraUpdates = 2;
            projectile.alpha = 255;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            Main.PlaySound(SoundID.Item10, projectile.position);

            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueStrong>(), projectile.velocity.X * -1, projectile.velocity.Y * -1);

            return false;
        }

        public override void AI()
        {
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 55; // Decrease alpha, increasing visibility.
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Lighting.AddLight(projectile.position, 0.7f, 0.7f, 0.9f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueSmall>());
            }
        }
    }
}