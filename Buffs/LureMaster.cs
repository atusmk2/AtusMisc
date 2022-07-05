using Terraria;
using Terraria.ModLoader;

namespace AtusMisc.Buffs
{
	public class LureMaster : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lure Master");
			Description.SetDefault("Chances to catch more fish!\nAlso increase your fishing power by 10.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.fishingSkill += 10;
		}
	}
}