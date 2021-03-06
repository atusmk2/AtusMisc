using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.ModLoader;
using AtusMisc.Common.Config;

namespace AtusMisc.NPCs {
	public class WeDoALittleBitTrolling : ModPlayer {
		
		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<ModOptions>().fishingTroll;
		}
		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
			bool unlucky = Main.rand.NextBool(1,5);
			bool spawn = false;
			int troll = 0;
			while (!spawn) {
				troll = Main.rand.Next(NPCLoader.NPCCount);
				NPC candidate = new NPC();
				candidate.SetDefaults(troll);
				if (!candidate.townNPC && !candidate.boss && !NPCID.Sets.IsTownPet[candidate.type] && !NPCID.Sets.ProjectileNPC[candidate.type] && !NPCID.Sets.ShouldBeCountedAsBoss[candidate.type] && (candidate.lifeMax < 400 || Main.hardMode)) {
					spawn = true;
				}
			}
			if (unlucky) {
				npcSpawn = troll;
				itemDrop = -1;
			}
		}
	}
}