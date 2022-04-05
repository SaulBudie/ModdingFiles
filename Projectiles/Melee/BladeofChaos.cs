using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tietank.Projectiles.Melee
{
	internal class BladeofChaos : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Blade of Chaos");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 64;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.melee = true;
			projectile.Tietank().RunicProjs = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Runic.SpartanFlames>(),5*60);
		}
        public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Runic.SpartanFlames>(), 4 * 60);
		}
        public int Timer;
		public override void AI()
		{

			Player player = Main.player[base.projectile.owner];
			TietankPlayer playerget = player.GetModPlayer<TietankPlayer>();
			if (player.dead)
			{
				base.projectile.Kill();
				return;
			}
			int newDirection = ((base.projectile.Center.X > player.Center.X) ? 1 : (-1));
			player.ChangeDir(newDirection);
			base.projectile.direction = newDirection;
			Vector2 vectorToPlayer = player.MountedCenter - base.projectile.Center;
			float currentChainLength = vectorToPlayer.Length();
			if (base.projectile.ai[0] == 0f)
			{
				float maxChainLength = 400f * playerget.ChainLength;
				base.projectile.tileCollide = false;
				if (currentChainLength > maxChainLength)
				{
					base.projectile.ai[0] = 1f;
					base.projectile.netUpdate = true;
				}
			}
			else if (base.projectile.ai[0] == 1f)
			{
				float elasticFactorA = 22f / player.meleeSpeed;
				float elasticFactorB = 1f / player.meleeSpeed;
				float maxStretchLength = 400f * playerget.ChainLength;
				if (base.projectile.ai[1] == 1f)
				{
					base.projectile.tileCollide = false;
				}
				if (!player.channel || currentChainLength > maxStretchLength || !base.projectile.tileCollide)
				{
					base.projectile.ai[1] = 1f;
					if (base.projectile.tileCollide)
					{
						base.projectile.netUpdate = true;
					}
					base.projectile.tileCollide = false;
					if (currentChainLength < 20f)
					{
						base.projectile.Kill();
					}
				}
				if (!base.projectile.tileCollide)
				{
					elasticFactorB *= 2f;
				}
				int restingChainLength = 54;
				if (currentChainLength > (float)restingChainLength || !base.projectile.tileCollide)
				{
					Vector2 elasticAcceleration = vectorToPlayer * elasticFactorA / currentChainLength - base.projectile.velocity;
					elasticAcceleration *= elasticFactorB / elasticAcceleration.Length();
					base.projectile.velocity *= 0.98f;
					base.projectile.velocity += elasticAcceleration;
				}
				else
				{
					if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 6f)
					{
						base.projectile.velocity.X *= 0.96f;
						base.projectile.velocity.Y += 0.2f;
					}
					if (player.velocity.X == 0f)
					{
						base.projectile.velocity.X *= 0.96f;
					}
				}
			}
			base.projectile.rotation = base.projectile.velocity.ToRotation() + ((base.projectile.spriteDirection == 1) ? 0f : ((float)Math.PI));
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			bool shouldMakeSound = false;
			if (oldVelocity.X != base.projectile.velocity.X)
			{
				if (Math.Abs(oldVelocity.X) > 4f)
				{
					shouldMakeSound = true;
				}
				base.projectile.position.X += base.projectile.velocity.X;
				base.projectile.velocity.X = (0f - oldVelocity.X) * 0.2f;
			}
			if (oldVelocity.Y != base.projectile.velocity.Y)
			{
				if (Math.Abs(oldVelocity.Y) > 4f)
				{
					shouldMakeSound = true;
				}
				base.projectile.position.Y += base.projectile.velocity.Y;
				base.projectile.velocity.Y = (0f - oldVelocity.Y) * 0.2f;
			}
			base.projectile.ai[0] = 1f;
			if (shouldMakeSound)
			{
				base.projectile.netUpdate = true;
				Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
				Main.PlaySound(0, (int)base.projectile.position.X, (int)base.projectile.position.Y);
			}
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = ModContent.GetTexture("Tietank/Projectiles/Melee/BladeofChaosG");
			int frameHeight = texture.Height / Main.projFrames[projectile.type];
			int y6 = frameHeight * projectile.frame;
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, y6, texture.Width, frameHeight), Color.White, projectile.rotation, new Vector2((float)texture.Width / 2f, (float)frameHeight / 2f), projectile.scale, spriteEffects, 0f);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Player player = Main.player[base.projectile.owner];
			Vector2 mountedCenter = player.MountedCenter;
			Texture2D chainTexture = ModContent.GetTexture("Tietank/Projectiles/Melee/Chainings");
			Vector2 drawPosition = base.projectile.Center;
			Vector2 remainingVectorToPlayer = mountedCenter - drawPosition;
			float rotation = remainingVectorToPlayer.ToRotation() - (float)Math.PI / 2f;
			if (base.projectile.alpha == 0)
			{
				int direction = -1;
				if (base.projectile.Center.X < mountedCenter.X)
				{
					direction = 1;
				}
				player.itemRotation = (float)Math.Atan2(remainingVectorToPlayer.Y * (float)direction, remainingVectorToPlayer.X * (float)direction);
			}
			while (true)
			{
				float length = remainingVectorToPlayer.Length();
				if (length < 25f || float.IsNaN(length))
				{
					break;
				}
				drawPosition += remainingVectorToPlayer * 12f / length;
				remainingVectorToPlayer = mountedCenter - drawPosition;
				Color color = new Color(255, 150, 38);
				spriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
			}

			return true;
		}
	}
}
