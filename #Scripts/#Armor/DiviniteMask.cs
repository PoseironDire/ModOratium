using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class DiviniteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Divinite Mask");
            Tooltip.SetDefault("10% increased throwing damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 22000;
            item.rare = 6;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DiviniteSuit>() && legs.type == ModContent.ItemType<DiviniteLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased throwing crit and velocity";
            player.thrownCost33 = true;
            player.thrownVelocity += 0.7f;
            player.thrownCrit += 12;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteBar"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}