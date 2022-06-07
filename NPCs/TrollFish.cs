using Microsoft.Xna.Framework;
using Terraria;
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
			bool unlucky = Main.rand.NextBool(1,3);
			bool spawn = false;
			int troll = 0;
			while (!spawn) {
				troll = Main.rand.Next(NPCLoader.NPCCount);
				NPC slap = new NPC();
				slap.SetDefaults(troll);
				if (!slap.townNPC && !slap.boss) {
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