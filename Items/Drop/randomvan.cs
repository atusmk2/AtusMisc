using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace AtusMisc.Items.Drop
{
	public class randomVan : ModItem
	{
        public override string Texture => "AtusMisc/Items/Drop/GachaCrystal";
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Throw into Extractinator to get random vanilla items.\n[c/FFD700:\"At least this doesn't cost irl money.\"]\n[c/FF0000:Disclaimer: May break your game when getting unobtainable item, use at your own risk!]");
            // Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            // ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            // ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = false;
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;

        }
       public override void SetDefaults() {
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Quest;
			Item.value = Item.buyPrice(gold: 50);
            Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.noUseGraphic = false;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
		}
		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.Gold.ToVector3() * 0.9f * Main.essScale);
		}
		public override void ExtractinatorUse(ref int resultType, ref int resultStack){
			int amogus = Main.rand.Next(1,5125);
            resultType = amogus;
			resultStack = 1;
		}
        // public override Color? GetAlpha(Color lightColor) {
        //     return new Color(50,50,50,0);
        // }
    }
}