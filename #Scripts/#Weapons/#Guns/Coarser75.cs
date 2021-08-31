using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ModOratium.Items.Weapons.Guns
{
    public class Coarser75 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coarser 75");
            Tooltip.SetDefault("18% chance to not consume ammo \nFires energized bullets \n'For the steady'");
        }

        public override void SetDefaults()
        {
            item.damage = 50; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.knockBack = 14; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            item.crit = 4; // Sets the item's critical strike chance
            item.width = 40; // hitbox width of the item
            item.height = 20; // hitbox height of the item
            item.value = 10000000; // how much the item sells for (measured in copper)
            item.rare = 7; // the color that the item's name will be in-game
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.useTime = 23; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 24; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.UseSound = SoundID.Item40; // mod.GetLegacySoundSlot(SoundType.Item, "Items/Sounds/gunShot"); // The sound that this item plays when used.
            item.shoot = 10; //idk why but all the guns ine the vanilla source have this
            item.shootSpeed = 28f; // the speed of the projectile (measured in pixels per frame)
            item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
            item.ranged = true; // sets the damage type to ranged
            item.noMelee = true; //so the item's animation doesn't do damage
            item.autoReuse = true; // if you can hold click to automatically use it again
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("EnergizedBulletProjectile");
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;

        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .18f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }
    }
}