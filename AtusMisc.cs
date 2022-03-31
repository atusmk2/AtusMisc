using Terraria;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using AtusMisc.Currencies;
using AtusMisc.Items.Drop;

namespace AtusMisc {
    public class AtusMisc : Mod {
        public static int Foodies;
        public override void Load()
        {
            Foodies = CustomCurrencyManager.RegisterCurrency(new FoodMoney(ModContent.ItemType<FoodCoupon>(), 1000L, "Food Coupon"));
        }
    }
}