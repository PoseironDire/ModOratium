using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Throwing
{
    public class BlisterThrowingScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Throwing Scythe");
            Tooltip.SetDefault("'A fast throwable schyte that passes through blocks.'");
        }

        public override void SetDefaults()
        {
            item.damage = 55;
            item.knockBack = 8;
            item.crit = 23;
            item.width = 20;
            item.height = 20;
            item.value = 90000;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 21;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("BlisterThrowingScytheProjectile");
            item.shootSpeed = 12f;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 10);
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