using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AtusMisc.Buffs
{
	public class LureMaster : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lure Master");
			Description.SetDefault("Chances to get more fishes!\nAlso increase your fishing level by 10.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false; // Add this so the nurse doesn't remove the buff when healing
		}
		public override void Update(Player player, ref int buffIndex) {
			player.fishingSkill += 10;
		}
	}
	internal class LureMasterPlayer : ModPlayer {
		public override void ModifyCaughtFish(Item fish) {
			if ( Player.HasBuff(ModContent.BuffType<LureMaster>()) && fish.rare != ItemRarityID.Quest) {
				fish.stack += Main.rand.Next(2, 5);
			}
		}
	}
}