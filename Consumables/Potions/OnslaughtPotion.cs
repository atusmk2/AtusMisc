using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using AtusMisc.Buffs;

namespace AtusMisc.Consumables.Potions {
	public class OnslaughtPotion : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I hope you can survive this...");
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
			Item.buffType = ModContent.BuffType<TheHorde>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 120; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
		/* public override void OnConsumeItem(Player Player) {
			Player.AddBuff(ModContent.BuffType<NegativeEffect1>(), 3600);
		} */
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.BattlePotion, 1)
				.AddRecipeGroup(RecipeGroupID.Scorpions, 5)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}