using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using AtusMisc.Consumables.Potions;

namespace AtusMisc.Items.Drop
{
	public class kusuri : ModItem
	{
		private static List<short> commonPotLesser = new List<short> { ItemID.LesserHealingPotion, ItemID.LesserManaPotion, ItemID.LesserRestorationPotion };
		private static List<short> commonPotNormal = new List<short> { ItemID.HealingPotion, ItemID.ManaPotion, ItemID.RegenerationPotion };
		private static List<long> combatPot = new List<long> { ItemID.IronskinPotion, ItemID.ArcheryPotion, ModContent.ItemType<OnslaughtPotion>(), ItemID.RagePotion, ItemID.WrathPotion, ItemID.BattlePotion, ItemID.MagicPowerPotion, ItemID.SwiftnessPotion, ItemID.SummoningPotion, ItemID.TitanPotion, ItemID.AmmoReservationPotion, ItemID.EndurancePotion, ItemID.InfernoPotion, ItemID.LifeforcePotion };
		private static List<short> exploPot = new List<short> { ItemID.NightOwlPotion, ItemID.ShinePotion, ItemID.MiningPotion, ItemID.GillsPotion, ItemID.WaterWalkingPotion, ItemID.FeatherfallPotion, ItemID.WarmthPotion, ItemID.ObsidianSkinPotion, ItemID.TrapsightPotion, ItemID.FlipperPotion, ItemID.GravitationPotion, ItemID.SpelunkerPotion, ItemID.PotionOfReturn, ItemID.RecallPotion };
		private static List<short> luckPot =  new List<short> { ItemID.LuckPotionLesser, ItemID.LuckPotion, ItemID.LuckPotionGreater};
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Throw into Extractinator to get potions.");
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;

		}
	   public override void SetDefaults() {
			Item.width = 20;
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
		// public override Color? GetAlpha(Color lightColor) {
		//     return new Color(255,255,255,0);
		// }
		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.7f * Main.essScale);
		}
		public override void ExtractinatorUse(ref int resultType, ref int resultStack) {
			int amogus = Main.rand.Next(1,16);
			if ( amogus == 15 ) {
			resultType = (int)luckPot[Main.rand.Next(luckPot.Count)];
			resultStack = 1;
			}
			if ( amogus > 10 && amogus < 15) {
			resultType = (int)combatPot[Main.rand.Next(combatPot.Count)];
			resultStack = 1;
			}
			if ( amogus > 6 && amogus < 11 ) {
			resultType = (int)exploPot[Main.rand.Next(exploPot.Count)];
			resultStack = 1;
			}
			if ( amogus > 4 && amogus < 7 ) {
			resultType = (int)commonPotNormal[Main.rand.Next(commonPotNormal.Count)];
			resultStack = 1;
			}
			if ( amogus < 5 ) {
			resultType = (int)commonPotLesser[Main.rand.Next(commonPotLesser.Count)];
			resultStack = 1;
			}
		}
	}
}