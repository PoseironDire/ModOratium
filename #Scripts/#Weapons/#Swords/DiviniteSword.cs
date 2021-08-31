using ModOratium.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Swords
{
    public class DiviniteSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinite Sword");
        }

        public override void SetDefaults()
        {
            item.damage = 135;
            item.knockBack = 6;
            item.crit = 8;
            item.width = 50;
            item.height = 50;
            item.value = 100000000;
            item.rare = 8;
            item.useStyle = 1;
            item.useTime = 11;
            item.useAnimation = 12;
            item.UseSound = SoundID.Item1;
            item.scale = 1.25f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(player.position, 0f, 0f, 0.5f);

                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<BlueSmall>());
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteBar"), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}