using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AtusMisc.Buffs {
public class LureMasterPlayer : ModPlayer {
		public override void ModifyCaughtFish(Item fish) {
			if ( Player.HasBuff(ModContent.BuffType<LureMaster>()) && fish.rare != ItemRarityID.Quest) {
				fish.stack += Main.rand.Next(2, 5);
			}
		}
	}
}