using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace AtusMisc.Items.Drop
{
	public class randomVanWeapon : ModItem
	{
        public override string Texture => "AtusMisc/Items/Drop/GachaCrystal";
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Throw into Extractinator to get random vanilla weapons.\n[c/FFD700:\"At least this doesn't cost irl money.\"]");
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;

        }
       public override void SetDefaults() {
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Quest;
			Item.value = Item.buyPrice(gold: 25);
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
			int amo = 0;
			int qa = 0;
			bool cu = false;
			while (!cu) {
				amo = Main.rand.Next(1, ItemLoader.ItemCount);
				Item nu = new Item();
				nu.SetDefaults(amo);
                int qu = nu.rare;
				if ((nu.CountsAsClass(DamageClass.Melee) || nu.CountsAsClass(DamageClass.Ranged) || nu.CountsAsClass(DamageClass.Magic) || nu.CountsAsClass(DamageClass.Summon)) && (qu <= 3 || Main.hardMode) && nu.maxStack == 1) {
					cu = true;
					qa = 1;
				}
				if ((nu.CountsAsClass(DamageClass.Melee) || nu.CountsAsClass(DamageClass.Ranged) || nu.CountsAsClass(DamageClass.Magic) || nu.CountsAsClass(DamageClass.Summon)) && (qu <= 3 || Main.hardMode) && nu.maxStack > 1) {
					cu = true;
					qa = Main.rand.Next(5,10);
				}
			}
			resultStack = qa;
			resultType = amo;
		}
    }
}