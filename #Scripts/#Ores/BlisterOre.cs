using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Ores
{
    public class BlisterOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Ore");
            Tooltip.SetDefault("'Straight Out Of Another Dimension'");
        }

        public override void SetDefaults()
        {
            item.createTile = mod.TileType("BlisterOreBlock");
            item.createTile = 6;
            item.maxStack = 999;
            item.width = 40;
            item.height = 40;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;
            item.value = 3000;
            item.rare = 4;
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