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
			Recipe dynamiteAlt = Recipe.Create(ItemID.Dynamite);
			dynamiteAlt.AddRecipeGroup(AnyBomb, 5);
			dynamiteAlt.AddRecipeGroup(AnySilverBar, 2);
			dynamiteAlt.AddTile(TileID.Anvils);
			dynamiteAlt.Register();
		}
	}
}