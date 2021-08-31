using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BlisterSuit : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Blister Suit");
            Tooltip.SetDefault("20% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 270000;
            item.rare = 4;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed *= 1.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}