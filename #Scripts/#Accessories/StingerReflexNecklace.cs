using System.Security.Cryptography;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class StningerReflexNecklace : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stninger Reflex Necklace");
            Tooltip.SetDefault("Increases armor penetration by 5 \nReleases bees and douses the user in honey when damaged \nIncreases movement speed after taking damage");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 20000;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration = player.armorPenetration + 5;
            player.bee = true;
            player.panic = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ItemID.HoneyComb);
            recipe.AddIngredient(ItemID.SharkToothNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.SharkToothNecklace);
            recipe2.AddIngredient(ItemID.SweetheartNecklace);
            recipe2.AddTile(TileID.TinkerersWorkbench);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}