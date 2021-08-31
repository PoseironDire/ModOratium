using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Swords
{
    public class BlisterSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Sword");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.knockBack = 4;
            item.crit = 20;
            item.width = 20;
            item.height = 20;
            item.value = 90000;
            item.rare = 4;
            item.useStyle = 1;
            item.useTime = 18;
            item.useAnimation = 19;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("BlisterSwordProjectile");
            item.shootSpeed = 10f;
            item.scale = 1.25f;
            item.melee = true;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(player.position, 0f, 0.2f, 0f);
            }
        }
    }
}