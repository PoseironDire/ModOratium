using ModOratium.Items.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Projectiles
{
    public class VampireArrowProjectile : ModProjectile
    {
        int Heal = 10;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Arrow");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.CloneDefaults(ProjectileID.VampireKnife);
            aiType = ProjectileID.VampireKnife;

            projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            if (projectile.ai[0] >= 15f)
            {
                projectile.ai[0] = 15f;
                projectile.velocity.Y = projectile.velocity.Y + 0.4f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            projectile.velocity.X = projectile.velocity.X * 0.97f; // 0.99f for rolling grenade speed reduction. Try values between 0.9f and 0.99f
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) // Lifesteal effect
        {
            int lifeSteal = damage / Heal; // Lifesteal vlue
            Main.player[projectile.owner].statLife += lifeSteal; // Lifesteal function
            Main.player[projectile.owner].HealEffect(lifeSteal, true); // Green number display
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 0f, 0f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<YellowSmall>());
            }
        }
    }
}