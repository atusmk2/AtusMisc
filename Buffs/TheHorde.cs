using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AtusMisc.Buffs
{
	public class TheHorde : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Goddamnit");
			Description.SetDefault("I hope you can survive.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
		}
	}
}
