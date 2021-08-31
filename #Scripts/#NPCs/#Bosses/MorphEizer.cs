using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModOratium.Items.NPCs.Bosses
{
    [AutoloadBossHead]
    public class MorphEizer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morph Eizer");
        }

        public override void SetDefaults()
        {
            npc.width = 100;
            npc.height = 100;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath10;
            npc.knockBackResist = 0;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = MusicID.Boss2;
            npc.aiStyle = 30;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1000 + numPlayers * 400;
            npc.damage = 50;
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                int choice = Main.rand.Next(4);
                if (choice == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Evamparus"));
                }
                else if (choice == 1)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Fantasmo"));
                }
                else if (choice == 2)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("BlisterDrifters"));
                }
                else if (choice == 3)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("DasherBoots"));
                }
            }
            else
            {
                int choice = Main.rand.Next(2);
                if (choice == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("DasherBoots"));
                }
                else if (choice == 1)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("BlisterDrifters"));
                }
            }

            if (Main.expertMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("BlisterOre"), Main.rand.Next(321));
            }
            else
            {
                Item.NewItem(npc.getRect(), mod.ItemType("BlisterOre"), Main.rand.Next(121));
            }

        }

    }
}