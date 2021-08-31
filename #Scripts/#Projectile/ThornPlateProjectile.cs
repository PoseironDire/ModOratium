using ModOratium.Items.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Projectiles
{
    public class ThornPlateProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn Plate");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before desapear 
            projectile.extraUpdates = 1;
            projectile.timeLeft = 400;
            projectile.alpha = 155;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            projectile.light = 0.5f;
            aiType = ProjectileID.Shuriken;
            projectile.thrown = true;
            projectile.friendly = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 53);

                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10); // sound that the projectile makes when hiting the terrain

                projectile.Kill();
            }
            return false;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 50f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 0.99f;    // projectile velocity
            }
        }
    }
}