using ModOratium.Items.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Projectiles
{
    public class FantasmoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fantasmo");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = 3;
            projectile.penetrate = 4;
            projectile.timeLeft = 1000;
            projectile.extraUpdates = 1;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(SoundID.Item11);

            Lighting.AddLight(projectile.position, 1f, 0.0f, 2f);

            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<GreenSmall>());
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0.1f, 0.8f, 0.1f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<GreenSmall>());
            }
        }
    }
}