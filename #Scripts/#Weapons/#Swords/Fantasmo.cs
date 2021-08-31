using ModOratium.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Swords
{
    public class Fantasmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fantasmo");
            Tooltip.SetDefault("'An energized katana that can be thrown'");
        }

        public override void SetDefaults()
        {
            item.damage = 140;
            item.knockBack = 10;
            item.crit = 30;
            item.width = 40;
            item.height = 40;
            item.value = 10000000;
            item.rare = 7;
            item.useStyle = 1;
            item.useTime = 11;
            item.useAnimation = 12;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 450;
                item.knockBack = 10;
                item.crit = 23;
                item.width = 22;
                item.height = 22;
                item.useStyle = 1;
                item.useTime = 10;
                item.useAnimation = 11;
                item.UseSound = SoundID.Item1;
                item.shoot = mod.ProjectileType("FantasmoProjectile");
                item.shootSpeed = 16f;
                item.melee = true;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.autoReuse = true;
            }
            else if (player.ownedProjectileCounts[item.shoot] < 1)
            {
                item.damage = 140;
                item.knockBack = 10;
                item.crit = 30;
                item.width = 22;
                item.height = 22;
                item.useStyle = 1;
                item.useTime = 11;
                item.useAnimation = 12;
                item.UseSound = SoundID.Item1;
                item.shoot = ProjectileID.None;
                item.melee = true;
                item.noMelee = false;
                item.noUseGraphic = false;
                item.useTurn = true;
                item.autoReuse = true;
            }
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(player.position, 0f, 0.2f, 0f);

                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GreenSmall>());
            }
        }
    }
}