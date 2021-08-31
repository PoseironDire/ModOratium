using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Accessories
{
    [AutoloadEquip(EquipType.Waist)]
    public class AmmoBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ammo Pocket");
            Tooltip.SetDefault("25% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 10000;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.ammoCost75 = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}