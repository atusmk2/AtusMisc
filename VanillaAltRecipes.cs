using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using AtusMisc.Items.Drop;

namespace AtusMisc {
	public class vanillaRecipeCustom : ModSystem
	{
		public static RecipeGroup AnySilverBar;
		public static RecipeGroup AnyBomb;
		public override void Unload() {
			AnySilverBar = null;
			AnyBomb = null;
		}
		public override void AddRecipeGroups() {
			AnySilverBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}",	ItemID.SilverBar, ItemID.TungstenBar);
			AnyBomb = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Bomb)}", ItemID.Bomb, ItemID.BombFish);
			RecipeGroup.RegisterGroup("AtusMisc:Any Silver Bar", AnySilverBar);
			RecipeGroup.RegisterGroup("AtusMisc:Any Bomb", AnyBomb);			
		}
		public override void AddRecipes() {
			Recipe dynamiteAlt = Mod.CreateRecipe(ItemID.Dynamite);
			dynamiteAlt.AddRecipeGroup(AnyBomb, 5);
			dynamiteAlt.AddRecipeGroup(AnySilverBar, 2);
			dynamiteAlt.AddTile(TileID.Anvils);
			dynamiteAlt.Register();

			/* Recipe n002 = Mod.CreateRecipe(ItemID.DayBloomPlanterBox, 1);
			n002.AddIngredient(ItemID.CopperCoin, 1);
			n002.Register();

			Recipe n003 = Mod.CreateRecipe(ItemID.SuspiciousLookingEye, 1);
			n003.AddIngredient(ItemID.CopperCoin, 1);
			n003.Register();

			Recipe n004 = Mod.CreateRecipe(ItemID.LifeCrystal, 1);
			n004.AddIngredient(ItemID.CopperCoin, 1);
			n004.Register(); */
		}
	}
}