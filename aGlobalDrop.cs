using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using AtusMisc.Items.Drop;

namespace AtusMisc {
	public class NewGlobalDrop : GlobalNPC {
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			List<int> normalDrop = new List<int> {
				ModContent.ItemType<kusuri>(),
				ModContent.ItemType<kajitsu>(),
				ModContent.ItemType<FoodCoupon>()
			};
			List<int> gachaDrop = new List<int> {
				ModContent.ItemType<randomVan>(),
				ModContent.ItemType<randomVanWeapon>()
			};

			if (!NPCID.Sets.CountsAsCritter[npc.type] && !NPCID.Sets.ProjectileNPC[npc.type] && !npc.townNPC) {
				npcLoot.Add(ItemDropRule.OneFromOptions(1000, gachaDrop.ToArray()));
				npcLoot.Add(ItemDropRule.OneFromOptions(100, normalDrop.ToArray()));
			}
			if (npc.boss) {
				npcLoot.Add(ItemDropRule.OneFromOptions(1, gachaDrop.ToArray()));
				npcLoot.Add(ItemDropRule.OneFromOptions(1, normalDrop.ToArray()));
			}
		}
	}
}