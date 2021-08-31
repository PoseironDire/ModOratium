using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Tools
{
    public class BlisterHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Hammer");
            Tooltip.SetDefault("'Fastest hammer out there!'");
        }

        public override void SetDefaults()
        {
            item.damage = 17;
            item.knockBack = 6;
            item.crit = 4;
            item.hammer = 85;
            item.width = 48;
            item.height = 48;
            item.value = 100000;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 5;
            item.useAnimation = 9;
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