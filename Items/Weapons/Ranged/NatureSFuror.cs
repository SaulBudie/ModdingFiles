using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Weapons.Ranged
{
	public class NatureSFuror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature's Furor");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(0, 1, 0 ,0);
			item.rare = ItemRarityID.Green;
			item.autoReuse = true;
			item.shoot = 1;
			item.crit = 10;
			item.knockBack = 6.5f;
			item.useStyle = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
			item.damage = 34;
			item.shootSpeed = 7f;
			item.noMelee = true;
			item.ranged = true;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Lighting.AddLight(item.Center, new Color(1, 255, 11).ToVector3() * 1);
		}

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2f, -6f);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int i = 0; i < 5; i++)

			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y,type, damage, knockBack, player.whoAmI); 
			}
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.Ranged.ChlorophyteBolt>(), damage, knockBack, player.whoAmI); 
			return false;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shotgun, 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 6);
			recipe.AddIngredient(ModContent.ItemType<Loots.PlanteraPetals>() ,5);
			recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();



		}






	}
}