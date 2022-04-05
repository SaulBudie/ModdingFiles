using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace Tietank.Items.Weapons.Melee
{
	public class AquaticBlade : ModItem
	{
		

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aquatic Blade");
			Tooltip.SetDefault("'Sometimes, it is good to give yourself a nice swim'\nCreates a tornado on hit\nWhen raining or in the ocean, the tornado can cause extra damage");
		}

        public override void SetDefaults()
		{
			item.damage = 62;
			item.melee = true;
			item.width = 40;
			item.height = 80;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 1);
			item.crit = 80;
			if(item.crit >= 100)
            {
				item.crit = 199;
            }

			item.useTurn = true;

		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-0f, -10f);
		}
		public class SolidOrPlatform : GenCondition
		{
			protected override bool CheckValidity(int x, int y)
			{
				Item item = new Item();
				Player player = Main.player[item.owner];
				if (player.IsUnderwater())
				{
					return true;
				}
				return false;
			}
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (item.owner != Main.myPlayer)
			{
				return;
			}
			int num229 = (int)(target.Center.Y / 16f);
			int num230 = (int)(target.Center.X / 16f);
			int num231 = 100;
			if (num230 < 10)
			{
				num230 = 10;
			}
			if (num230 > Main.maxTilesX - 10)
			{
				num230 = Main.maxTilesX - 10;
			}
			if (num229 < 10)
			{
				num229 = 10;
			}
			if (num229 > Main.maxTilesY - num231 - 10)
			{
				num229 = Main.maxTilesY - num231 - 10;
			}
			for (int num232 = num229; num232 < num229 + num231; num232++)
			{
				Tile tile = Main.tile[num230, num232];
				if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
				{
					num229 = num232;
					break;
				}
			}
			int num234 = item.damage +(player.ZoneBeach ? item.damage / 5: 0) + (Main.raining ? item.damage / 5 : 0);
			int num2324 = item.damage;
			if (Main.rand.Next(6) < 5)
			{
				int num236 = Projectile.NewProjectile(num230 * 16 + 8, num229 * 16 - 24, 0f, 0f, ModContent.ProjectileType<Projectiles.Melee.TornadoWater>(), num234 * 2, 4f, Main.myPlayer, 16f, 15f + ( 0f));
				Main.projectile[num236].netUpdate = true;
			}
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit)
		{
			if (item.owner != Main.myPlayer)
			{
				return;
			}
			int num229 = (int)(target.Center.Y / 16f);
			int num230 = (int)(target.Center.X / 16f);
			int num231 = 100;
			if (num230 < 10)
			{
				num230 = 10;
			}
			if (num230 > Main.maxTilesX - 10)
			{
				num230 = Main.maxTilesX - 10;
			}
			if (num229 < 10)
			{
				num229 = 10;
			}
			if (num229 > Main.maxTilesY - num231 - 10)
			{
				num229 = Main.maxTilesY - num231 - 10;
			}
			for (int num232 = num229; num232 < num229 + num231; num232++)
			{
				Tile tile = Main.tile[num230, num232];
				if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
				{
					num229 = num232;
					break;
				}
			}
			if (Main.rand.Next(6) < 5)
			{
				int num234 = (Main.expertMode ? 180 : 300);
				int num236 = Projectile.NewProjectile(num230 * 16 + 8, num229 * 16 - 24, 0f, 0f, ModContent.ProjectileType<Projectiles.Melee.TornadoWater>(), num234, 4f, Main.myPlayer, 16f, 15f + (0f));
				Main.projectile[num236].netUpdate = true;
			}
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(6))
			{
				int num250 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Water, player.direction * 3, 0f, 150, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1.3f);
				Main.dust[num250].velocity *= 0.2f;
				Main.dust[num250].noGravity = true;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BladeofGrass, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 25);
			recipe.AddIngredient(ModContent.ItemType<Items.Loots.PlanteraPetals>(), 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.Acorn, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
