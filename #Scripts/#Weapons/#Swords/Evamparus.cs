using ModOratium.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Swords
{
    public class Evamparus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evamparus");
            Tooltip.SetDefault("'???...'");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.knockBack = 7;
            item.crit = 10;
            item.width = 20;
            item.height = 20;
            item.value = 10000000;
            item.rare = 7;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 16;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("EvamparusProjectile");
            item.shootSpeed = 8f;
            item.melee = true;
            item.autoReuse = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(player.position, 0f, 0f, 0.5f);
            }
        }
    }
}