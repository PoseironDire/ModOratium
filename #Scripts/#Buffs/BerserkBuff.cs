using ModOratium.Items.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Buffs
{
    public class BerserkBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berserk");
            Description.SetDefault("Lose all defence in exchange for doubled damage.");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 100;
            player.allDamage *= 2;
        }
    }
}