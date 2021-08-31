using ModOratium.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Projectiles
{
    public class AdamantiumBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantium Bullet");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;               //The width of projectile hitbox
            projectile.height = 8;              //The height of projectile hitbox
            projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.penetrate = 5;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 240;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.alpha = 240;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
            projectile.ranged = true;            //Is the projectile shoot by a ranged weapon?
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) // Lifesteal effect
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<YellowStrong>(), projectile.velocity.X * 2, projectile.velocity.Y * 2);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<YellowStrong>(), projectile.velocity.X * 2.1f, projectile.velocity.Y * 2.1f);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<YellowStrong>(), projectile.velocity.X * 2.2f, projectile.velocity.Y * 2.2f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item11, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0.3f, 0.3f, 0f); // Add Light 

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<YellowSmall>()); // Add Particle
            }
        }
    }
}