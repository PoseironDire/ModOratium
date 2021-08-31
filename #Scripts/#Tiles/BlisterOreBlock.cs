using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ModOratium.Items.Tiles
{
    public class BlisterOreBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileValue[Type] = 650; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = 3f;
            minPick = 70;
            drop = mod.ItemType("BlisterOre");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Blister Ore");
            AddMapEntry(new Color(30, 255, 20));
            soundType = 21;
            soundStyle = 1;
            dustType = 84;
        }

    }
}