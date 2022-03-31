using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework.Graphics;

namespace AtusMisc.Items.Drop
{
	public class FoodCoupon : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Use this to buy food from Snack Lady.");
			ItemID.Sets.ItemNoGravity[Item.type] = false;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1000;

        }
       public override void SetDefaults() {
			Item.width = 18; // 46
			Item.height = 26; // 22
			Item.maxStack = 1000;
			Item.rare = 2;
		}
		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
		}
        /* public override Color? GetAlpha(Color lightColor) {
            return new Color(255,255,255,0);
        } */
    }
}