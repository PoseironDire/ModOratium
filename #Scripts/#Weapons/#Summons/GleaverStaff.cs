using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Summons
{
    public class GleaverStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gleaver Staff");
            Tooltip.SetDefault("Summons a Gleaver minion to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.knockBack = 3f;
            item.mana = 10;
            item.width = 32;
            item.height = 32;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.value = 1000000;
            item.rare = 6;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = ModContent.BuffType<Buffs.GleaverBuff>();
            item.shoot = ModContent.ProjectileType<Projectiles.GleaverMinionProjectile>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(item.buffType, 2);

            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
            position = Main.MouseWorld;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AdamantiumBar"), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
