using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace AtusMisc.Currencies
{
	public class FoodMoney : CustomCurrencySingleCoin
	{
		public FoodMoney(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap) {
			this.CurrencyTextKey = CurrencyTextKey;
			CurrencyTextColor = Color.YellowGreen;
		}
	}
}