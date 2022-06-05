using Terraria;
using Terraria.ModLoader;

namespace AtusMisc.Buffs {
public class newGlobalSpawnRate : GlobalNPC
	{
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
		   if ( Main.expertMode ) {
				maxSpawns = (int)((double)maxSpawns * 1.8);
			}
			if ( Main.masterMode ) {
				maxSpawns = (int)((double)maxSpawns * 1.5);
			}

			if (player.HasBuff(ModContent.BuffType<TheHorde>())) {
				spawnRate = 1;
				maxSpawns = 200;
			}
		}
	}
}