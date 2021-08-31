using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace ModOratium
{
    public class ModOratium : Mod
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup corruptedMushroom = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Corrupted Mushroom", new int[]
            {
                ItemID.VileMushroom,
                ItemID.ViciousMushroom
            });
            RecipeGroup.RegisterGroup("CorruptedMushroom", corruptedMushroom);

            RecipeGroup higherMetal = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Higher Metal", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("HigherMetal", higherMetal);

        }

    }
}