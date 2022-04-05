using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tietank.Projectiles.Melee
{
	public class TornadoWater : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Aquatic Tornado");
			Main.projFrames[base.projectile.type] = 8;
		}

		public override void SetDefaults()
		{
			Player player = Main.player[projectile.owner];
			base.projectile.width = 146;
			base.projectile.height = 48;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.penetrate = -1;
			base.projectile.alpha = 255;
			base.projectile.timeLeft = 600;
			base.cooldownSlot = 1;
			projectile.localNPCHitCooldown = 1;
			projectile.damage = projectile.damage ;
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(base.projectile.localAI[0]);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.projectile.localAI[0] = reader.ReadSingle();
		}
		public float sex;
		public override void AI()
		{
			float ebase = 24f;
			float mult = 1f;
			float width = 146f;
			float height = 48f;
			if (base.projectile.velocity.X != 0f)
			{
				base.projectile.direction = (base.projectile.spriteDirection = -Math.Sign(base.projectile.velocity.X));
			}
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter > 2)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
			}
			if (base.projectile.frame >= Main.projFrames[base.projectile.type])
			{
				base.projectile.frame = 0;
			}
			if (base.projectile.localAI[0] == 0f)
			{
				base.projectile.localAI[0] = 1f;
				base.projectile.scale = (ebase - base.projectile.ai[1]) * mult / ebase;
				TietankProjectile.openout(base.projectile, (int)(width * base.projectile.scale), (int)(height * base.projectile.scale));
				base.projectile.netUpdate = true;
			}
			if (base.projectile.ai[1] != -1f)
			{
				base.projectile.scale = (ebase - base.projectile.ai[1]) * mult / ebase;
				base.projectile.width = (int)(width * base.projectile.scale);
				base.projectile.height = (int)(height * base.projectile.scale);
			}
			if (!Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
			{
				base.projectile.alpha -= 30;
				if (base.projectile.alpha < 60)
				{
					base.projectile.alpha = 60;
				}
			}
			else
			{
				base.projectile.alpha += 30;
				if (base.projectile.alpha > 150)
				{
					base.projectile.alpha = 150;
				}
			}
			if (base.projectile.ai[0] > 0f)
			{
				base.projectile.ai[0] -= 1f;
			}
			if (base.projectile.ai[0] == 1f && base.projectile.ai[1] > 0f && base.projectile.owner == Main.myPlayer)
			{
				base.projectile.netUpdate = true;
				Vector2 center = base.projectile.Center;
				center.Y -= height * base.projectile.scale / 2f;
				float num618 = (ebase - base.projectile.ai[1] + 1f) * mult / ebase;
				center.Y -= height * num618 / 2f;
				center.Y += 2f;
				Projectile.NewProjectile(center, base.projectile.velocity, base.projectile.type, base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 11f, base.projectile.ai[1] - 1f);
			}
			if (base.projectile.ai[0] <= 0f)
			{
				float num619 = (float)base.projectile.width / 5f;
				num619 *= 2f;
				float num620 = (float)(Math.Cos(0.10471975803375244 * (0.0 - (double)base.projectile.ai[0])) - 0.5) * num619;
				base.projectile.position.X -= num620 * (float)(-base.projectile.direction);
				base.projectile.ai[0] -= 1f;
				num620 = (float)(Math.Cos(0.10471975803375244 * (0.0 - (double)base.projectile.ai[0])) - 0.5) * num619;
				base.projectile.position.X += num620 * (float)(-base.projectile.direction);
			}

		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D13 = Main.projectileTexture[base.projectile.type];
			int num214 = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y6 = num214 * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D13, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle(0, y6, texture2D13.Width, num214), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D13.Width / 2f, (float)num214 / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(103, 240);
			target.AddBuff(ModContent.BuffType<Buffs.Speed.HarshWinds>(), 240);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Wet, 240);
			target.AddBuff(ModContent.BuffType<Buffs.Speed.HarshWinds>(), 240);
		}

    }
}
