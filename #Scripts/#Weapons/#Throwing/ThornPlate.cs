using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.Weapons.Throwing
{
    public class ThornPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn Plate");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.damage = 30;
            item.knockBack = 6;
            item.crit = 4;
            item.width = 20;
            item.height = 20;
            item.value = 1000;
            item.rare = 6;
            item.useStyle = 2;
            item.useTime = 9;
            item.useAnimation = 9;
            item.reuseDelay = 9;    //this is the item delay
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ThornPlateProjectile");  //javelin projectile
            item.shootSpeed = 8f;
            item.thrown = true;             //this make the item do throwing damage
            item.noMelee = true;
            item.consumable = true;  //this make the item consumable when used
            item.useTurn = true;
            item.autoReuse = false;       //this make the item auto reuse
            item.noUseGraphic = true;

        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteOre"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}