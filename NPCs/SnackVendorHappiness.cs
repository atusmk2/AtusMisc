using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace AtusMisc.NPCs
{
	public class SnackVendorHappiness : GlobalNPC 
	{
		public override void SetStaticDefaults() {
			int townNpcType = ModContent.NPCType<SnackVendor>();
			var merchanHappiness = NPCHappiness.Get(NPCID.Merchant);
			var guideHappiness = NPCHappiness.Get(NPCID.Guide);

			guideHappiness.SetNPCAffection(townNpcType, AffectionLevel.Love);
			merchanHappiness.SetNPCAffection(townNpcType, AffectionLevel.Like);
		}
	}
}
