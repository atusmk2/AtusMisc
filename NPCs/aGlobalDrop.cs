using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using AtusMisc.Items.Drop;

namespace AtusMisc.NPCs {
	public class NewGlobalDrop : GlobalNPC {
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (!NPCID.Sets.CountsAsCritter[npc.type] && !NPCID.Sets.ProjectileNPC[npc.type] && !npc.townNPC) {
				npcLoot.Add(ItemDropRule.OneFromOptions(1000, ModContent.ItemType<RandomVan>(),	ModContent.ItemType<RandomVanWeapon>()));
				npcLoot.Add(ItemDropRule.OneFromOptions(100, ModContent.ItemType<Kusuri>(), ModContent.ItemType<Kajitsu>(), ModContent.ItemType<FoodCoupon>()));
			}
			if (npc.boss) {
				npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<RandomVan>(), ModContent.ItemType<RandomVanWeapon>()));
				npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<Kusuri>(), ModContent.ItemType<Kajitsu>(), ModContent.ItemType<FoodCoupon>()));
			}
		}
	}
}