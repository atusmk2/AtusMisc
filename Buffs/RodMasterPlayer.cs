using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace AtusMisc.Buffs {
	public class RodMasterPlayer : ModPlayer {
		public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Player player = Main.LocalPlayer;
			if ((player.HeldItem.fishingPole > 0 && player.HeldItem.fishingPole < 1000) && player.HasBuff(ModContent.BuffType<RodMaster>())) {
				int bobberAmount = Main.rand.Next(2,5);
				float spreadAmount = 10f;
				for (int index = 0; index < bobberAmount; ++index) {
					Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
					Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
				}
				return false;
			}
			return true;
		}
	}
}