using System;
using ModOratium.Items.Dusts;
using ModOratium.Items;
using ModOratium.Items.Bars;
using ModOratium.Items.Weapons.Spears;
using ModOratium.Items.Projectiles;
using ModOratium.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ModOratium.Items.NPCs.TownNPCs
{
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Biden : ModNPC
    {
        public override string Texture => "OratiumMod/Items/NPCs/TownNPCs/Biden";

        public override string[] AltTextures => new[] { "OratiumMod/Items/NPCs/TownNPCs/Biden_Alt_1" };

        public override bool Autoload(ref string name)
        {
            name = "President";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 250;
            npc.damage = 10;
            npc.defense = 15;
            npc.knockBackResist = 0.5f;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = NPCID.Guide;
            npc.townNPC = true;
            npc.friendly = true;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<BlueSmall>());
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType<BlisterBar>() || item.type == ModContent.ItemType<DoulgarSpear>())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /*
                // Example Person needs a house built out of OratiumMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
                public override bool CheckConditions(int left, int right, int top, int bottom) {
                    int score = 0;
                    for (int x = left; x <= right; x++) {
                        for (int y = top; y <= bottom; y++) {
                            int type = Main.tile[x, y].type;
                            if (type == ModContent.TileType<ExampleBlock>() || type == ModContent.TileType<ExampleChair>() || type == ModContent.TileType<ExampleWorkbench>() || type == ModContent.TileType<ExampleBed>() || type == ModContent.TileType<ExampleDoorOpen>() || type == ModContent.TileType<ExampleDoorClosed>()) {
                                score++;
                            }
                            if (Main.tile[x, y].wall == ModContent.WallType<ExampleWall>()) {
                                score++;
                            }
                        }
                    }
                    return score >= (right - left) * (bottom - top) / 2;
                }
        */
        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Biden";
                case 1:
                    return "Joe";
                case 2:
                    return "Joe Biden";
                default:
                    return "Mr. Biden";
            }
        }

        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        public override string GetChat()
        {
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Sometimes I feel like I'm different from everyone else here.";
                case 1:
                    return "What's your favorite color? My favorite colors are white and black.";
                case 2:
                    return "Hey you, ask Trump what the Wifi Password is in The White House";
                default:
                    return "Will you shut up man.";
            }
        }
        bool upgrade = true;
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            if (upgrade == true)
            {
                button2 = "Deal";
                if (Main.LocalPlayer.HasItem(ItemID.TerraBlade))
                    button = "Upgrade! " + Lang.GetItemNameValue(ItemID.TerraBlade);
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                if (upgrade == true)
                {
                    // We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
                    if (Main.LocalPlayer.HasItem(ItemID.TerraBlade))
                    {
                        Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
                        Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.TerraBlade)} to a {Lang.GetItemNameValue(ModContent.ItemType<Items.Weapons.Swords.Deathbringer>())}";
                        int terraBladeItemIndex = Main.LocalPlayer.FindItem(ItemID.TerraBlade);
                        Main.LocalPlayer.inventory[terraBladeItemIndex].TurnToAir();
                        Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.Weapons.Swords.Deathbringer>());
                        upgrade = false;
                        return;
                    }
                }
                shop = true;
            }
            else
            {
                if (upgrade == true)
                {
                    // Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
                    Main.npcChatCornerItem = ItemID.TerraBlade;
                    Main.npcChatText = $"Hey, if you find a [i:{ItemID.TerraBlade}], I can make you an upgraded version.";
                    shop = false;
                }
            }
            if (upgrade == false)
            {
                shop = true;
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("BlisterBar"));
            nextSlot++;
        }
        /*
                    if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleHealingPotion>());
                        nextSlot++;
                    }
                    if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !ModContent.GetInstance<ExampleConfigServer>().DisableExampleWings) {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleWings>());
                        nextSlot++;
                    }
                    if (Main.moonPhase < 2) {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleSword>());
                        nextSlot++;
                    }
                    else if (Main.moonPhase < 4) {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleGun>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.ExampleBullet>());
                        nextSlot++;
                    }
                    else if (Main.moonPhase < 6) {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleStaff>());
                        nextSlot++;
                    }
        */

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Accessories.AmmoBag>());
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<AdamantiumBulletProjectile>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}