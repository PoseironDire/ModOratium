using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Ammo
{
    public class AdamantiumBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantium Bullet");
            Tooltip.SetDefault("'Speedy reflective bullets'");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.damage = 10;
            item.knockBack = 2;
            item.crit = 4;
            item.width = 8;
            item.height = 8;
            item.rare = 4;
            item.value = 10;
            item.shoot = ModContent.ProjectileType<Projectiles.AdamantiumBulletProjectile>();
            item.shootSpeed = 15;
            item.ammo = AmmoID.Bullet;
            item.ranged = true;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AdamantiumBar"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}