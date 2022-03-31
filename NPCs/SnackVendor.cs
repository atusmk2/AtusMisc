using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using AtusMisc.Items.Drop;

namespace AtusMisc.NPCs {
    [AutoloadHead]
    public class SnackVendor : ModNPC {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 23;

            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.AttackType[Type] = 1;
            NPCID.Sets.AttackTime[Type] = 60;
            NPCID.Sets.AttackAverageChance[Type] = 15;
            NPCID.Sets.DangerDetectRange[Type] = 200;
            NPCID.Sets.HatOffsetY[Type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawMod = new NPCID.Sets.NPCBestiaryDrawModifiers(0){
                Velocity = 1f, Direction = 1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawMod);

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Like)
                .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate)
            ;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 40;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Stylist;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("This lovely lady sells snack and food rarely dropped from enemy.\nShe only accept \"food coupon\" as payment method though.")
            });
        }
        public override void HitEffect(IEntitySource hitSource, int hitDirection, double damage) {
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++) {
				Dust.NewDust(hitSource, NPC.position, NPC.width, NPC.height, DustID.Blood);
			}
		}
        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			Player player = Main.LocalPlayer;
            if (player.inventory.Any(item => item.type == ModContent.ItemType<FoodCoupon>())){
            return true;
            }
            return false;
		}
        public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Sayuri";

				case 1:
					return "Kotoha";

				case 2:
					return "Miharu";

				default:
					return "Anna";
			}
		}
        public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();
            int guideGuy = NPC.FindFirstNPC(NPCID.Guide);
            int oldMan = NPC.FindFirstNPC(NPCID.Merchant);
            if (guideGuy > 0 && Main.rand.NextBool(3)) {
                chat.Add("U-Uh... " + Main.npc[guideGuy].GivenName + " is kinda, lovely? Isn't?");
            }
            if (oldMan > 0 && Main.rand.NextBool(5)) {
                chat.Add(Main.npc[guideGuy].GivenName + " showing me rope in the trade, I respect him.");
            }
            chat.Add("Welcome to Snack Co. - " + Main.worldName + " Branch. Enjoy our wares!" );
			chat.Add("Sorry, I wish I could sell these to you with normal coins, but for some reason my distributor only accept those strange coupon.");
            if ( !NPC.downedBoss1 ) {
			chat.Add("I feel insecure with that giant eyeball flying around. I promise I'll sell you more food if you can slay it!");
            }
            if ( !NPC.downedBoss2 && WorldGen.crimson ) {
			chat.Add("That horrifying brain monster has distrupted our supply lines, if you can blast it away my distributor said we can provide you with more food to sell!");
            }
            if ( !NPC.downedBoss2 && !WorldGen.crimson ) {
			chat.Add("I got new update from my distributor, they said they can supply us with new shipments if you can destroy the terrain-destroying giant worm that halted our operation.");
            }
            if ( !NPC.downedBoss3 && NPC.downedBoss1 && NPC.downedBoss2 ) {
			chat.Add("Last obstacle for our smooth commerce, A GIANT FLYING SKELETON! Defeat it and we all set here.");
            }
            if ( NPC.downedBoss3 && NPC.downedBoss1 && NPC.downedBoss2 ) {
			chat.Add("Thank you for your good work, we can trade safely now, I hope...");
            }
			chat.Add("I wish I made better choice in life, sob...", 0.1);
			return chat;
		}
        public override void SetChatButtons(ref string button, ref string button2) { 
            button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.MilkCarton);
            shop.item[nextSlot].shopCustomPrice = 2;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.PotatoChips);
            shop.item[nextSlot].shopCustomPrice = 3;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            if (NPC.downedBoss1) {
            shop.item[nextSlot].SetDefaults(ItemID.BananaSplit);
            shop.item[nextSlot].shopCustomPrice = 5;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.CoffeeCup);
            shop.item[nextSlot].shopCustomPrice = 5;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Fries);
            shop.item[nextSlot].shopCustomPrice = 5;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ChickenNugget);
            shop.item[nextSlot].shopCustomPrice = 6;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.IceCream);
            shop.item[nextSlot].shopCustomPrice = 6;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.FriedEgg);
            shop.item[nextSlot].shopCustomPrice = 6;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            }
            if (NPC.downedBoss2) {
            shop.item[nextSlot].SetDefaults(ItemID.Nachos);
            shop.item[nextSlot].shopCustomPrice = 7;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Grapes);
            shop.item[nextSlot].shopCustomPrice = 7;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.CreamSoda);
            shop.item[nextSlot].shopCustomPrice = 7;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ShrimpPoBoy);
            shop.item[nextSlot].shopCustomPrice = 8;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ChocolateChipCookie);
            shop.item[nextSlot].shopCustomPrice = 9;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Hotdog);
            shop.item[nextSlot].shopCustomPrice = 9;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            }
            if (NPC.downedBoss3) {
            shop.item[nextSlot].SetDefaults(ItemID.Burger);
            shop.item[nextSlot].shopCustomPrice = 6;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Pizza);
            shop.item[nextSlot].shopCustomPrice = 6;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ApplePie);
            shop.item[nextSlot].shopCustomPrice = 12;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Milkshake);
            shop.item[nextSlot].shopCustomPrice = 12;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Steak);
            shop.item[nextSlot].shopCustomPrice = 12;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Bacon);
            shop.item[nextSlot].shopCustomPrice = 15;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.BBQRibs);
            shop.item[nextSlot].shopCustomPrice = 15;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.GoldenDelight);
            shop.item[nextSlot].shopCustomPrice = 35;
            shop.item[nextSlot].shopSpecialCurrency = AtusMisc.Foodies;
            nextSlot++;
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 5000, 1, 1));
		}
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.LaserMachinegunLaser;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 16f;
            randomOffset = 2f;
        }
        public override void TownNPCAttackShoot(ref bool inBetweenShots){
            inBetweenShots = true;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 1;
        }
        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 0.8f;
            closeness = 5;
            item = ItemID.LaserMachinegun;
        }
    }
}