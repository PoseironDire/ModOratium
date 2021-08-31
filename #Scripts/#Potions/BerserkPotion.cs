using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Potions
{
    public class BerserkPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserk Potion");
            Tooltip.SetDefault("Lose all defence in exchange for doubled damage.");
        }

        public override void SetDefaults()
        {
            item.buffType = ModContent.BuffType<Buffs.BerserkBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 5400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
            item.maxStack = 30;
            item.width = 20;
            item.height = 26;
            item.value = 10000;
            item.rare = 6;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTime = 15;
            item.useAnimation = 16;
            item.UseSound = SoundID.Item3;
            item.useTurn = true;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.DoubleCod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddRecipeGroup("CorruptedMushroom");
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}