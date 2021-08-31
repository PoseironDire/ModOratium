using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Souls
{
    public class SoulofIgnite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Ignite");
            Tooltip.SetDefault("'The essence of Enlighted creatures'");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.maxStack = 999;
            item.width = refItem.width;
            item.height = refItem.height;
            item.value = 2000;
            item.rare = 6;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.Purple.ToVector3() * 1f * Main.essScale);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}