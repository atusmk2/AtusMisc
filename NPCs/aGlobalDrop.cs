using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using AtusMisc.Items.Drop;

namespace AtusMisc.NPCs {
	public class NewGlobalDrop : GlobalNPC {
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			List<int> normalDrop = new List<int> {
				ModContent.ItemType<Kusuri>(),
				ModContent.ItemType<Kajitsu>(),
				ModContent.ItemType<FoodCoupon>()
			};
			List<int> gachaDrop = new List<int> {
				ModContent.ItemType<RandomVan>(),
				ModContent.ItemType<RandomVanWeapon>()
			};
			int result = 0;
			bool roll = false;
			while (!roll) {
				result = Main.rand.Next(1, ItemLoader.ItemCount);
				Item item = new Item();
				item.SetDefaults(result);
				if (item.createTile > 0) {
					roll = true;
				}
			}
			
			if (!NPCID.Sets.CountsAsCritter[npc.type] && !NPCID.Sets.ProjectileNPC[npc.type] && !npc.townNPC) {
				npcLoot.Add(ItemDropRule.OneFromOptions(1000, gachaDrop.ToArray()));
				npcLoot.Add(ItemDropRule.OneFromOptions(100, normalDrop.ToArray()));
				npcLoot.Add(ItemDropRule.Common(result,50,1,1));
			}
			if (npc.boss) {
				npcLoot.Add(ItemDropRule.OneFromOptions(1, gachaDrop.ToArray()));
				npcLoot.Add(ItemDropRule.OneFromOptions(1, normalDrop.ToArray()));
			}
		}
	}
}