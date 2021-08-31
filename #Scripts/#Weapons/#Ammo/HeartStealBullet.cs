using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Ammo
{
    public class HeartStealBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Steal Bullet");
            Tooltip.SetDefault("'Healing bullets'");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.damage = 5;
            item.knockBack = 2;
            item.crit = 4;
            item.width = 8;
            item.height = 8;
            item.rare = 4;
            item.value = 10;
            item.shoot = ModContent.ProjectileType<Projectiles.HeartStealBulletProjectile>();
            item.shootSpeed = 15;
            item.ammo = AmmoID.Bullet;
            item.ranged = true;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}