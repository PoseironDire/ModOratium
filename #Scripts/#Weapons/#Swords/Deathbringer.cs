using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Swords
{
    public class Deathbringer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deathbringer");
            Tooltip.SetDefault("'Bringer of Death, what can i say..'");
        }

        public override void SetDefaults()
        {
            item.damage = 931;
            item.knockBack = 4;
            item.crit = 200;
            item.width = 20;
            item.height = 20;
            item.value = 100000;
            item.rare = 10;
            item.useStyle = 1;
            item.useTime = 7;
            item.useAnimation = 8;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = true;
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