using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using AtusMisc.Items.Drop;
using AtusMisc.NPCs;

namespace AtusMisc {
    public class vanillaShopEdit : GlobalNPC {
		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			if ( type == NPCID.Merchant ) {
				shop.item[nextSlot].SetDefaults(ItemID.Bottle);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
				nextSlot++;
				if ( NPC.downedBoss2 ) {
					shop.item[nextSlot].SetDefaults(ItemID.JourneymanBait);
					nextSlot++;
				}
				if ( Main.hardMode ) {
					shop.item[nextSlot].SetDefaults(ItemID.MasterBait);
					nextSlot++;
				}
                if ( NPC.FindFirstNPC(ModContent.NPCType<SnackVendor>()) >= 1 ) {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<FoodCoupon>());
                    shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
                }
			}
			if ( type == NPCID.Demolitionist ) {
				if ( Main.LocalPlayer.HasItem(ItemID.ScarabBomb)) {
					shop.item[nextSlot++].SetDefaults(ItemID.ScarabBomb);
				}
			}
		}
        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            base.SetupTravelShop(shop, ref nextSlot);
			shop[nextSlot++] = ModContent.ItemType<randomVan>();
        }
    }
}