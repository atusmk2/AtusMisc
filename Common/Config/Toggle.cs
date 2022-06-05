using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace AtusMisc.Common.Config
{
	public class toggleOptions : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		[Header("$Mods.AtusMisc.Config.vanillaShop")] // Test
		[Label("$Mods.AtusMisc.Config.shopToggle.Label")] // Label
		[Tooltip("$Mods.AtusMisc.Config.shopToggle.Tooltip")] // Tooltip
		[DefaultValue(true)]
		[ReloadRequired]
		public bool shopToggle;
		[Header("$Mods.AtusMisc.Config.fishingRod")] // Test
		[Label("$Mods.AtusMisc.Config.rodEdit.Label")] // Label
		[Tooltip("$Mods.AtusMisc.Config.rodEdit.Tooltip")] // Tooltip
		[DefaultValue(true)]
		[ReloadRequired]
		public bool fishingRodEdit;
	}
}