using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Weapons.Melee
{
	public class UnoDeck : ModItem
	{
		

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uno Deck");
			Tooltip.SetDefault("'Shoots Uno cards'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 9));
		}

        public override void SetDefaults()
		{
			item.damage = 57;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 15;
			item.useAnimation = 15;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noMelee = true;
			item.value = Item.sellPrice(gold: 1);
			item.knockBack = 10;
			item.shoot = ModContent.ProjectileType<Projectiles.Melee.Uno4>();
			item.shootSpeed = 10f;
			item.useTurn = true;
		}
		public override void UseStyle(Player player)
		{
			player.itemLocation += new Vector2(-12f * (float)player.direction, 12f * player.gravDir).RotatedBy(player.itemRotation);
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Lighting.AddLight(item.position, Main.DiscoColor.ToVector3() * 1f);

		}
		// How can I choose between several projectiles randomly?
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<Projectiles.Melee.UnoY>(), ModContent.ProjectileType<Projectiles.Melee.UnoR>(), ModContent.ProjectileType<Projectiles.Melee.UnoG>(), ModContent.ProjectileType<Projectiles.Melee.UnoB>() });
			return true;
		}
	}
}