using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Tools
{
    public class BlisterAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Axe");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.knockBack = 6;
            item.crit = 20;
            item.axe = 22;
            item.width = 48;
            item.height = 48;
            item.value = 90000;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 12;
            item.useAnimation = 13;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 9);
            recipe.AddIngredient(mod.ItemType("SoulofIgnite"), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}