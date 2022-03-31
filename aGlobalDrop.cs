using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AtusMisc.Items.Drop;

namespace Atusmisc {
    public class NewGlobalDrop : GlobalNPC {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (!NPCID.Sets.CountsAsCritter[npc.type] && !NPCID.Sets.ProjectileNPC[npc.type] && !npc.townNPC) {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kusuri>(),100,1,2));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kajitsu>(),200,1,2));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FoodCoupon>(),100,1,2));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<randomVan>(),20000,1,2));
			}
            if ( npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.KingSlime || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.QueenBee  || npc.type == NPCID.DD2DarkMageT1 ) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kusuri>(),1,2,5));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kajitsu>(),1,2,5));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FoodCoupon>(),1,2,5));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<randomVan>(),5,1,1));
            }
            if ( npc.type == NPCID.SkeletronHead || npc.type == NPCID.WallofFlesh || npc.type == NPCID.DD2OgreT2 ) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kusuri>(),1,5,10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kajitsu>(),1,5,10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FoodCoupon>(),1,5,10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<randomVan>(),5,2,2));
            }
            if ( npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer  || npc.type == NPCID.DD2DarkMageT3 || npc.type == NPCID.DD2OgreT3 ) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kusuri>(),1,10,15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kajitsu>(),1,10,15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FoodCoupon>(),1,10,15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<randomVan>(),5,3,3));
            }
            if ( npc.type == NPCID.Plantera || npc.type == NPCID.Golem || npc.type == NPCID.QueenSlimeBoss || npc.type == NPCID.IceQueen || npc.type == NPCID.Pumpking || npc.type == NPCID.DD2Betsy || npc.type == NPCID.MartianSaucerCore ) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kusuri>(),1,15,20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kajitsu>(),1,15,20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FoodCoupon>(),1,15,20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<randomVan>(),5,4,4));
            }
            if ( npc.type == NPCID.CultistBoss || npc.type == NPCID.MoonLordCore ) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kusuri>(),1,20,25));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<kajitsu>(),1,20,25));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FoodCoupon>(),1,20,25));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<randomVan>(),5,5,5));
            }
        }
    }
}