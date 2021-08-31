using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Throwing
{
    public class BlisterDrifters : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Drifters");
            Tooltip.SetDefault("'Two really fast throwable daggers.'");
        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.knockBack = 2;
            item.crit = 23;
            item.width = 20;
            item.height = 20;
            item.value = 135000;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 21;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("BlisterDriftersProjectile");
            item.shootSpeed = 10;
            item.ranged = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}