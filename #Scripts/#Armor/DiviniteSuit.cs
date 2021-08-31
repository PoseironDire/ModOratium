using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DiviniteSuit : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Divinite Suit");
            Tooltip.SetDefault("30% increased throwing damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 370000;
            item.rare = 6;
            item.defense = 32;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.3f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteBar"), 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}