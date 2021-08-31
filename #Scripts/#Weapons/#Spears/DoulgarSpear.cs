using ModOratium.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Spears
{
    public class DoulgarSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doulgar Spear");
            Tooltip.SetDefault("'A faster variant of the Spear'");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.knockBack = 3;
            item.crit = 4;
            item.width = 22;
            item.height = 22;
            item.value = 1000000;
            item.rare = 3;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 34;
            item.useAnimation = 24;
            item.UseSound = SoundID.Item1;
            item.scale = 1;
            item.shoot = ModContent.ProjectileType<DoulgarSpearProjectile>();
            item.shootSpeed = 2.7f;
            item.melee = true;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spear);
            recipe.AddRecipeGroup("HigherMetal", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}