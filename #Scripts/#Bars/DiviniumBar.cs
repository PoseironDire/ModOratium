using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Bars
{
    public class DiviniteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinite Bar");
            Tooltip.SetDefault("'¤Has]Been?Avoid?!'");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.value = 12000;
            item.rare = 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteOre"), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}