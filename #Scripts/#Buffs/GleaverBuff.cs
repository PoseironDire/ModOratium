using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Buffs
{
    public class GleaverBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gleaver");
            Description.SetDefault("The Gleaver will fight & provide healing for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.GleaverMinionProjectile>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}