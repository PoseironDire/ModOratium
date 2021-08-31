using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Magic
{
    public class VampiresTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Vampires Tome");
        }

        public override void SetDefaults()
        {
            item.damage = 70;
            item.knockBack = 4;
            item.crit = 4;
            item.mana = 6;
            item.width = 28;
            item.height = 38;
            item.value = 40000;
            item.rare = 7;
            item.useStyle = 5;
            item.useTime = 16;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item20;
            item.shoot = ProjectileID.VampireKnife;
            item.shootSpeed = 14f;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2 + Main.rand.Next(3); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(15);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AdamantiumBar"), 12);
            recipe.AddIngredient(mod.ItemType("SoulofIgnite"), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}