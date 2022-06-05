using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using AtusMisc.Buffs;

namespace AtusMisc.Consumables.Potions {
	public class LuremasterPotion : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lure Master Potion");
			Tooltip.SetDefault("Increase your fishing yield and skill.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = 2;
			Item.value = Item.buyPrice(gold: 1);
			Item.sellPrice(silver: 20);
			Item.buffType = ModContent.BuffType<LureMaster>();
			Item.buffTime = 28800;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.FishingPotion)
				.AddIngredient(ItemID.FallenStar, 5)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}