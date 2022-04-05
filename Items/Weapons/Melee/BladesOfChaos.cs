using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Weapons.Melee
{
	internal class BladesOfChaos : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Blades Of Chaos");
			base.Tooltip.SetDefault("'Zeus, your son has returned! I bring the destruction of Olympus!'\nThrows the max of two blades of chaos\nRight click to create a huge blast\nThe blast will heal the player and damage enemies\nThe blast has a 10 second cool down");
		} 

		public override void SetDefaults()
		{
			base.item.width = 50;
			base.item.height = 56;
			item.value = Item.sellPrice(gold: 2, silver: 50);
			base.item.rare = ItemRarityID.Red;
			base.item.noMelee = true;
			base.item.useStyle = 1;
			base.item.useAnimation = 15;
			base.item.useTime = 15;
			base.item.knockBack = 3.75f;
			base.item.damage = sex;
			base.item.noUseGraphic = true;
			base.item.shootSpeed = 30;
			item.Tietank().RunicItems = true;
			base.item.melee = true;
			base.item.autoReuse = true;
		}
		public int sex = 130;
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && player.Tietank().BladesOfChaosCoolDown <= 0)
			{
				item.damage = sex;
				base.item.shoot = ModContent.ProjectileType<Projectiles.Melee.BOC>();
				base.item.shootSpeed = 1f;

				base.item.UseSound = SoundID.Item14;
				player.Tietank().BladesOfChaosCoolDown = 60 * 10;
			}
			else if (player.altFunctionUse == 2 && player.Tietank().BladesOfChaosCoolDown > 0)
            {
				item.damage = sex;
				base.item.shoot = 0;
				base.item.shootSpeed = 0f;

				base.item.UseSound = SoundID.Item1;
			}
			else
			{
				item.damage = sex;
				base.item.shoot = ModContent.ProjectileType<Projectiles.Melee.BladeofChaos>();
				base.item.shootSpeed = 30f;

				base.item.UseSound = SoundID.Item1;
			}
			return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.BladeofChaos>()] < 2;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
			Lighting.AddLight(item.position, Color.Orange.ToVector3() * 1);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)speedX, (int)speedY, type, damage*2, knockBack, player.whoAmI);
			}
			else
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3f));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

	}
}
