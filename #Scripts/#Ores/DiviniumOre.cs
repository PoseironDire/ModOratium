using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Ores
{
    public class DiviniteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinite Ore");
            Tooltip.SetDefault("'¤Has]Been?Avoid?!'");
        }

        public override void SetDefaults()
        {
            item.createTile = mod.TileType("DiviniteOreBlock");
            item.createTile = 6;
            item.maxStack = 999;
            item.width = 40;
            item.height = 40;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;
            item.value = 4000;
            item.rare = 6;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}