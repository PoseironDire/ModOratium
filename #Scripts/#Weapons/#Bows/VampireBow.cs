using ModOratium.Items.Projectiles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Bows
{
    public class VampireBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Bow");
        }

        public override void SetDefaults()
        {
            item.damage = 120; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.knockBack = 8; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            item.crit = 4; // Sets the item's critical strike chance
            item.width = 40; // hitbox width of the item
            item.height = 20; // hitbox height of the item
            item.value = 100000; // how much the item sells for (measured in copper)
            item.rare = 4; // the color that the item's name will be in-game
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.useTime = 15; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 16; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.UseSound = SoundID.Item5; // The sound that this item plays when used.
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 35f; // the speed of the projectile (measured in pixels per frame)
            item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
            item.ranged = true; // sets the damage type to ranged
            item.noMelee = true; //so the item's animation doesn't do damage
            item.autoReuse = true; // if you can hold click to automatically use it again
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("VampireArrowProjectile");


            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
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