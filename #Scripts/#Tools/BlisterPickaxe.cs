using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Tools
{
    public class BlisterPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.knockBack = 6;
            item.crit = 4;
            item.pick = 205;
            item.width = 48;
            item.height = 48;
            item.value = 180000;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 1;
            item.useAnimation = 8;
            item.UseSound = SoundID.Item1;
            item.scale = 1.3f;
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 18);
            recipe.AddIngredient(mod.ItemType("SoulofIgnite"), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}