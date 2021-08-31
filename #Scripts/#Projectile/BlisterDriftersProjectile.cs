using ModOratium.Items.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Projectiles
{
    public class BlisterDriftersProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Drifters");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 3;
            projectile.penetrate = 2;
            projectile.timeLeft = 1000;
            projectile.extraUpdates = 2;
            projectile.melee = true;
            projectile.friendly = true;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0f, 1f, 0f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<GreenSmall>());
            }
        }
    }
}