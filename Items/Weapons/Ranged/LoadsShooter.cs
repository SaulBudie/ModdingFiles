using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Weapons.Ranged
{
	public class LoadsShooter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Loads Shooter");
			string a = "'Quite durable isn't it?'\nShoots extra white sprays";
			base.Tooltip.SetDefault(a);
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(0, 1, 0 ,0);
			item.rare = ItemRarityID.LightRed;
			item.shoot = 1;
			item.crit = 10;
			item.knockBack = 6.5f;
			item.useStyle = 5;
			item.useAnimation = 32;
			item.useTime = 32;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
			item.damage = 31;
			item.shootSpeed = 7.6f;
			item.noMelee = true;
			item.ranged = true;
		}

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2f, -6f);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int i = 0; i < 5; i++)

			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y,type, damage, knockBack, player.whoAmI);
			}
			for (int i = 0; i < 3; i++)

			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(14));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Projectiles.Ranged.WhiteSprays>(), damage, knockBack, player.whoAmI);
			}
			return false;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.NutBlaster>());
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();



		}






	}
}