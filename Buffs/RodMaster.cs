using Terraria;
using Terraria.ModLoader;

namespace AtusMisc.Buffs
{
	public class RodMaster : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rod Master");
			Description.SetDefault("More bobbers!\nAlso increase your fishing power by 10.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.fishingSkill += 10;
		}
	}
}