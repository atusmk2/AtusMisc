using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace AtusMisc.Common.Config
{
	public class ModOptions : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		[Header("$Mods.AtusMisc.Config.vanillaShop")] // Test
		[Label("$Mods.AtusMisc.Config.shopToggle.Label")] // Label
		[Tooltip("$Mods.AtusMisc.Config.shopToggle.Tooltip")] // Tooltip
		[DefaultValue(true)]
		[ReloadRequired]
		public bool shopToggle;
		[Header("$Mods.AtusMisc.Config.fishingTroll")] // Test
		[Label("$Mods.AtusMisc.Config.enableTroll.Label")] // Label
		[Tooltip("$Mods.AtusMisc.Config.enableTroll.Tooltip")] // Tooltip
		[DefaultValue(true)]
		[ReloadRequired]
		// [ReloadRequired]
		public bool fishingTroll;
		}
}