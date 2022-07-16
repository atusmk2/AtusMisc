using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using AtusMisc.Buffs;

namespace AtusMisc.Consumables.Potions {
	public class DangerzonePotion : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I hope you can survive this...");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = 2;
			Item.value = Item.buyPrice(silver: 20);
			Item.buffType = ModContent.BuffType<TheHorde>();
			Item.buffTime = 300;
		}
		
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.BattlePotion, 1)
				.AddRecipeGroup(RecipeGroupID.Scorpions, 5)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}