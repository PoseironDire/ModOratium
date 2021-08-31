using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class DiviniteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Divinite Leggings");
            Tooltip.SetDefault("25% increased throwing damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 315000;
            item.rare = 6;
            item.defense = 26;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.25f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteBar"), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}