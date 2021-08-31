using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Summons
{
    public class MorphEizerSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tiny Blistered Eizer");
            Tooltip.SetDefault("Summons the MorphEizer \n 'Don't Set It Free, Unless..'");
        }

        public override void SetDefaults()
        {
            item.maxStack = 30;
            item.width = 20;
            item.height = 20;
            item.value = 0;
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 40;
            item.UseSound = SoundID.Item1;
            item.scale = 0.5f;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("MorphEizer"));
            return !alreadySpawned && !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("MorphEizer"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}