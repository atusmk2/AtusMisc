using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using AtusMisc.Common.Config;

namespace AtusMisc.Items.Tools {
	public class ModifiedChumCaster : GlobalItem {
		public override bool IsLoadingEnabled(Mod mod)
		{
			return ModContent.GetInstance<toggleOptions>().fishingRodEdit;
		}
		public override bool AppliesToEntity(Item entity, bool lateInstantiation)
		{
			return entity.type == ItemID.BloodFishingRod;
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			TooltipLine nut = new TooltipLine(Mod, "AtusMisc", "Shoot three boobers at once.");
			tooltips.Add(nut);
		}
		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int bobberAmount = 3;
			float spreadAmount = 30f;

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}
	}
	public class ModifiedFiberRod : GlobalItem {
		public override bool IsLoadingEnabled(Mod mod)
		{
			return ModContent.GetInstance<toggleOptions>().fishingRodEdit;
		}
		public override bool AppliesToEntity(Item entity, bool lateInstantiation)
		{
			return entity.type == ItemID.FiberglassFishingPole;
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			TooltipLine nut = new TooltipLine(Mod, "AtusMisc", "Shoot two boobers at once.");
			tooltips.Add(nut);
		}
		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int bobberAmount = 2;
			float spreadAmount = 75f;

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}
	}
	public class ModifiedHotlineRod : GlobalItem {
		public override bool IsLoadingEnabled(Mod mod)
		{
			return ModContent.GetInstance<toggleOptions>().fishingRodEdit;
		}
		public override bool AppliesToEntity(Item entity, bool lateInstantiation)
		{
			return entity.type == ItemID.HotlineFishingHook;
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			TooltipLine nut = new TooltipLine(Mod, "AtusMisc", "Shoot five boobers at once.");
			tooltips.Add(nut);
		}
		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int bobberAmount = 5;
			float spreadAmount = 20f;

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}
	}
	public class ModifiedGoldenPole : GlobalItem {
		public override bool IsLoadingEnabled(Mod mod)
		{
			return ModContent.GetInstance<toggleOptions>().fishingRodEdit;
		}

		public override bool AppliesToEntity(Item entity, bool lateInstantiation)
		{
			return entity.type == ItemID.GoldenFishingRod;
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			TooltipLine nut = new TooltipLine(Mod, "AtusMisc", "Shoot 2-4 boobers at once.");
			tooltips.Add(nut);
		}
		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int bobberAmount = Main.rand.Next(2, 5);
			float spreadAmount = 40f;

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}
	}
}