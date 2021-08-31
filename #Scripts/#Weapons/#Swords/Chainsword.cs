using ModOratium.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Swords
{
    public class Chainsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chainsword");
            Tooltip.SetDefault("'A great tool, for slaughter..'");
        }

        public override void SetDefaults()
        {
            item.damage = 220;
            item.knockBack = 10;
            item.crit = 30;
            item.axe = 25;
            item.width = 40;
            item.height = 40;
            item.value = 10000000;
            item.rare = 7;
            item.useStyle = 1;
            item.useTime = 31;
            item.useAnimation = 32;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = false;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(player.position, 0.5f, 0.5f, 0.1f);

                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<YellowSmall>());
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}