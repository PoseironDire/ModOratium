using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Accessories.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class BlisterWings : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Wings");
            Tooltip.SetDefault("Allows flight and slow fall");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 10000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 200;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1.1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 12f;
            acceleration *= 2.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 18);
            recipe.AddIngredient(mod.ItemType("SoulofIgnite"), 6);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}