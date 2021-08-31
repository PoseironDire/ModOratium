using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BlisterHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Blister Mask");
            Tooltip.SetDefault("10% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 180000;
            item.rare = 4;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed *= 1.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BlisterSuit>() && legs.type == ModContent.ItemType<BlisterLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% increased melee damage";
            player.meleeDamage += 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}