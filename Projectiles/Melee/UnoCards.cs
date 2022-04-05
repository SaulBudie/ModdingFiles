using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Projectiles.Melee
{

	public class UnoY : ModProjectile
	{

		public override void SetDefaults()
		{
			base.projectile.width = 14;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.penetrate = -1;
			base.projectile.aiStyle = 3;
			base.aiType = 52;
			projectile.timeLeft = 300;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 120);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 120);
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(base.projectile.localAI[0]);
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustType = DustID.TopazBolt;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.projectile.localAI[0] = reader.ReadSingle();
		}

		public override void AI()
		{

			Lighting.AddLight(projectile.position, Color.Yellow.ToVector3() * 1f);
			int[] array = new int[20];
			int num428 = 0;
			float num429 = 300f;
			bool flag14 = false;
			for (int num430 = 0; num430 < 200; num430++)
			{
				if (!Main.npc[num430].CanBeChasedBy(base.projectile))
				{
					continue;
				}
				float num431 = Main.npc[num430].position.X + (float)(Main.npc[num430].width / 2);
				float num432 = Main.npc[num430].position.Y + (float)(Main.npc[num430].height / 2);
				if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num431) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num432) < num429 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
				{
					if (num428 < 20)
					{
						array[num428] = num430;
						num428++;
					}
					flag14 = true;
				}
			}
			if (!flag14)
			{
				return;
			}
			int num433 = Main.rand.Next(num428);
			num433 = array[num433];
			float num434 = Main.npc[num433].position.X + (float)(Main.npc[num433].width / 2);
			float num435 = Main.npc[num433].position.Y + (float)(Main.npc[num433].height / 2);
			base.projectile.localAI[0] += 1f;
			if (!(base.projectile.localAI[0] > 8f))
			{
				return;
			}
			base.projectile.localAI[0] = 0f;
			Vector2 value10 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			value10 += base.projectile.velocity * 4f;
			float num438 = num434 - value10.X;
			float num436 = num435 - value10.Y;
			float num437 = (float)Math.Sqrt(num438 * num438 + num436 * num436);
			num437 = 6f / num437;
			if (!Main.rand.NextBool(5) || base.projectile.owner != Main.myPlayer)
			{
				return;
			}
			float spread = 1.044f;
			double startAngle = Math.Atan2(base.projectile.velocity.X, base.projectile.velocity.Y) - (double)(spread / 2f);
			double deltaAngle = spread / 6f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.ai[0] = 1f;
			base.projectile.localAI[0] = 0f;
			base.projectile.width = (base.projectile.height = 60);
			base.projectile.tileCollide = false;
			base.projectile.netUpdate = true;
			if (base.projectile.velocity.X != oldVelocity.X)
			{
				base.projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (base.projectile.velocity.Y != oldVelocity.Y)
			{
				base.projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return false;
		}



	}

	public class UnoR : ModProjectile
	{

		public override void SetDefaults()
		{
			base.projectile.width = 14;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.penetrate = -1;
			base.projectile.aiStyle = 3;
			base.aiType = 52;
			projectile.timeLeft = 300;
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustType = DustID.RubyBolt;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
        public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(base.projectile.localAI[0]);
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire,120);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 120);
		}
		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.projectile.localAI[0] = reader.ReadSingle();
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Color.Red.ToVector3() * 1f);
			int[] array = new int[20];
			int num428 = 0;
			float num429 = 300f;
			bool flag14 = false;
			for (int num430 = 0; num430 < 200; num430++)
			{
				if (!Main.npc[num430].CanBeChasedBy(base.projectile))
				{
					continue;
				}
				float num431 = Main.npc[num430].position.X + (float)(Main.npc[num430].width / 2);
				float num432 = Main.npc[num430].position.Y + (float)(Main.npc[num430].height / 2);
				if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num431) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num432) < num429 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
				{
					if (num428 < 20)
					{
						array[num428] = num430;
						num428++;
					}
					flag14 = true;
				}
			}
			if (!flag14)
			{
				return;
			}
			int num433 = Main.rand.Next(num428);
			num433 = array[num433];
			float num434 = Main.npc[num433].position.X + (float)(Main.npc[num433].width / 2);
			float num435 = Main.npc[num433].position.Y + (float)(Main.npc[num433].height / 2);
			base.projectile.localAI[0] += 1f;
			if (!(base.projectile.localAI[0] > 8f))
			{
				return;
			}
			base.projectile.localAI[0] = 0f;
			Vector2 value10 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			value10 += base.projectile.velocity * 4f;
			float num438 = num434 - value10.X;
			float num436 = num435 - value10.Y;
			float num437 = (float)Math.Sqrt(num438 * num438 + num436 * num436);
			num437 = 6f / num437;
			if (!Main.rand.NextBool(5) || base.projectile.owner != Main.myPlayer)
			{
				return;
			}
			float spread = 1.044f;
			double startAngle = Math.Atan2(base.projectile.velocity.X, base.projectile.velocity.Y) - (double)(spread / 2f);
			double deltaAngle = spread / 6f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.ai[0] = 1f;
			base.projectile.localAI[0] = 0f;
			base.projectile.width = (base.projectile.height = 60);
			base.projectile.tileCollide = false;
			base.projectile.netUpdate = true;
			if (base.projectile.velocity.X != oldVelocity.X)
			{
				base.projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (base.projectile.velocity.Y != oldVelocity.Y)
			{
				base.projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return false;
		}



	}
	public class UnoB : ModProjectile
	{

		public override void SetDefaults()
		{

			base.projectile.width = 14;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.penetrate = -1;
			base.projectile.aiStyle = 3;
			base.aiType = 52;
			projectile.timeLeft = 300;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 120);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 120);
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustType = DustID.SapphireBolt;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(base.projectile.localAI[0]);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.projectile.localAI[0] = reader.ReadSingle();
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Color.Blue.ToVector3() * 1f);
			int[] array = new int[20];
			int num428 = 0;
			float num429 = 300f;
			bool flag14 = false;
			for (int num430 = 0; num430 < 200; num430++)
			{
				if (!Main.npc[num430].CanBeChasedBy(base.projectile))
				{
					continue;
				}
				float num431 = Main.npc[num430].position.X + (float)(Main.npc[num430].width / 2);
				float num432 = Main.npc[num430].position.Y + (float)(Main.npc[num430].height / 2);
				if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num431) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num432) < num429 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
				{
					if (num428 < 20)
					{
						array[num428] = num430;
						num428++;
					}
					flag14 = true;
				}
			}
			if (!flag14)
			{
				return;
			}
			int num433 = Main.rand.Next(num428);
			num433 = array[num433];
			float num434 = Main.npc[num433].position.X + (float)(Main.npc[num433].width / 2);
			float num435 = Main.npc[num433].position.Y + (float)(Main.npc[num433].height / 2);
			base.projectile.localAI[0] += 1f;
			if (!(base.projectile.localAI[0] > 8f))
			{
				return;
			}
			base.projectile.localAI[0] = 0f;
			Vector2 value10 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			value10 += base.projectile.velocity * 4f;
			float num438 = num434 - value10.X;
			float num436 = num435 - value10.Y;
			float num437 = (float)Math.Sqrt(num438 * num438 + num436 * num436);
			num437 = 6f / num437;
			if (!Main.rand.NextBool(5) || base.projectile.owner != Main.myPlayer)
			{
				return;
			}
			float spread = 1.044f;
			double startAngle = Math.Atan2(base.projectile.velocity.X, base.projectile.velocity.Y) - (double)(spread / 2f);
			double deltaAngle = spread / 6f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.ai[0] = 1f;
			base.projectile.localAI[0] = 0f;
			base.projectile.width = (base.projectile.height = 60);
			base.projectile.tileCollide = false;
			base.projectile.netUpdate = true;
			if (base.projectile.velocity.X != oldVelocity.X)
			{
				base.projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (base.projectile.velocity.Y != oldVelocity.Y)
			{
				base.projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return false;
		}



	}
	public class Uno4 : ModProjectile
	{

		public override void SetDefaults()
		{
			base.projectile.width = 14;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.penetrate = -1;
			base.projectile.aiStyle = 3;
			base.aiType = 52;
			projectile.timeLeft = 300;
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustType = DustID.RainbowMk2;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(base.projectile.localAI[0]);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.projectile.localAI[0] = reader.ReadSingle();
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 120);
			target.AddBuff(BuffID.Ichor, 120);
			target.AddBuff(BuffID.Frostburn, 120);
			target.AddBuff(BuffID.DryadsWardDebuff, 120);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 120);
			target.AddBuff(BuffID.Ichor, 120);
			target.AddBuff(BuffID.Frostburn, 120);
			target.AddBuff(BuffID.DryadsWardDebuff, 120);
		}
		public override void AI()
		{
			Lighting.AddLight(projectile.position, Main.DiscoColor.ToVector3() * 1f);
			int[] array = new int[20];
			int num428 = 0;
			float num429 = 300f;
			bool flag14 = false;
			for (int num430 = 0; num430 < 200; num430++)
			{
				if (!Main.npc[num430].CanBeChasedBy(base.projectile))
				{
					continue;
				}
				float num431 = Main.npc[num430].position.X + (float)(Main.npc[num430].width / 2);
				float num432 = Main.npc[num430].position.Y + (float)(Main.npc[num430].height / 2);
				if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num431) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num432) < num429 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
				{
					if (num428 < 20)
					{
						array[num428] = num430;
						num428++;
					}
					flag14 = true;
				}
			}
			if (!flag14)
			{
				return;
			}
			int num433 = Main.rand.Next(num428);
			num433 = array[num433];
			float num434 = Main.npc[num433].position.X + (float)(Main.npc[num433].width / 2);
			float num435 = Main.npc[num433].position.Y + (float)(Main.npc[num433].height / 2);
			base.projectile.localAI[0] += 1f;
			if (!(base.projectile.localAI[0] > 8f))
			{
				return;
			}
			base.projectile.localAI[0] = 0f;
			Vector2 value10 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			value10 += base.projectile.velocity * 4f;
			float num438 = num434 - value10.X;
			float num436 = num435 - value10.Y;
			float num437 = (float)Math.Sqrt(num438 * num438 + num436 * num436);
			num437 = 6f / num437;
			if (!Main.rand.NextBool(5) || base.projectile.owner != Main.myPlayer)
			{
				return;
			}
			float spread = 1.044f;
			double startAngle = Math.Atan2(base.projectile.velocity.X, base.projectile.velocity.Y) - (double)(spread / 2f);
			double deltaAngle = spread / 6f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.ai[0] = 1f;
			base.projectile.localAI[0] = 0f;
			base.projectile.width = (base.projectile.height = 60);
			base.projectile.tileCollide = false;
			base.projectile.netUpdate = true;
			if (base.projectile.velocity.X != oldVelocity.X)
			{
				base.projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (base.projectile.velocity.Y != oldVelocity.Y)
			{
				base.projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return false;
		}



	}

	public class UnoG : ModProjectile
	{

		public override void SetDefaults()
		{
			base.projectile.width = 14;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.penetrate = -1;
			base.projectile.aiStyle = 3;
			base.aiType = 52;
			projectile.timeLeft = 300;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.DryadsWardDebuff, 120);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.DryadsWardDebuff, 120);
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustType = DustID.EmeraldBolt;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(base.projectile.localAI[0]);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.projectile.localAI[0] = reader.ReadSingle();
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, Color.Green.ToVector3() * 1f);
			int[] array = new int[20];
			int num428 = 0;
			float num429 = 300f;
			bool flag14 = false;
			for (int num430 = 0; num430 < 200; num430++)
			{
				if (!Main.npc[num430].CanBeChasedBy(base.projectile))
				{
					continue;
				}
				float num431 = Main.npc[num430].position.X + (float)(Main.npc[num430].width / 2);
				float num432 = Main.npc[num430].position.Y + (float)(Main.npc[num430].height / 2);
				if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num431) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num432) < num429 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
				{
					if (num428 < 20)
					{
						array[num428] = num430;
						num428++;
					}
					flag14 = true;
				}
			}
			if (!flag14)
			{
				return;
			}
			int num433 = Main.rand.Next(num428);
			num433 = array[num433];
			float num434 = Main.npc[num433].position.X + (float)(Main.npc[num433].width / 2);
			float num435 = Main.npc[num433].position.Y + (float)(Main.npc[num433].height / 2);
			base.projectile.localAI[0] += 1f;
			if (!(base.projectile.localAI[0] > 8f))
			{
				return;
			}
			base.projectile.localAI[0] = 0f;
			Vector2 value10 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			value10 += base.projectile.velocity * 4f;
			float num438 = num434 - value10.X;
			float num436 = num435 - value10.Y;
			float num437 = (float)Math.Sqrt(num438 * num438 + num436 * num436);
			num437 = 6f / num437;
			if (!Main.rand.NextBool(5) || base.projectile.owner != Main.myPlayer)
			{
				return;
			}
			float spread = 1.044f;
			double startAngle = Math.Atan2(base.projectile.velocity.X, base.projectile.velocity.Y) - (double)(spread / 2f);
			double deltaAngle = spread / 6f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.ai[0] = 1f;
			base.projectile.localAI[0] = 0f;
			base.projectile.width = (base.projectile.height = 60);
			base.projectile.tileCollide = false;
			base.projectile.netUpdate = true;
			if (base.projectile.velocity.X != oldVelocity.X)
			{
				base.projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (base.projectile.velocity.Y != oldVelocity.Y)
			{
				base.projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return false;
		}


		
	}
}
