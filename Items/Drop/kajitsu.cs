using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace AtusMisc.Items.Drop
{
	public class Kajitsu : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Throw into Extractinator to get fruits.");
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;

		}
	   public override void SetDefaults() {
			Item.width = 24;
			Item.height = 26;
			Item.maxStack = 999;
			Item.rare = 2;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.noUseGraphic = false;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
		}
		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.7f * Main.essScale);
		}
		public override void ExtractinatorUse(ref int resultType, ref int resultStack){
			List<short> fruitsDrop = new List<short> { ItemID.Apple, ItemID.Apricot, ItemID.Banana, ItemID.BlackCurrant, ItemID.BloodOrange, ItemID.Cherry, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Elderberry,ItemID.Grapefruit, ItemID.Lemon, ItemID.Mango, ItemID.Peach, ItemID.Pineapple, ItemID.Plum, ItemID.Rambutan, ItemID.Starfruit };
			resultType = (int)fruitsDrop[Main.rand.Next(fruitsDrop.Count)];
			resultStack = 1;
		}
		// public override Color? GetAlpha(Color lightColor) {
		//     return new Color(255,255,255,0);
		// }
	}
}