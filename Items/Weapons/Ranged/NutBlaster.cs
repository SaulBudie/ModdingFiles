using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Weapons.Ranged
{
	public class NutBlaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nut Blaster");
			string a = "'Its burst is stronger than the confetti's poppers'";
			base.Tooltip.SetDefault(a);
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(0, 1, 0 ,0);
			item.rare = ItemRarityID.Orange;
			item.autoReuse = false;
			item.shoot = 1;
			item.crit = 10;
			item.knockBack = 6.5f;
			item.useStyle = 5;
			item.useAnimation = 35;
			item.useTime = 35;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
			item.damage = 26;
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
			for (int i = 0; i < 6; i++)

			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y,type, damage, knockBack, player.whoAmI); 
			}
			return false;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shotgun, 1);
			recipe.AddIngredient(ItemID.Actuator, 10);
			recipe.AddRecipeGroup(RecipeGroupID.Wood,15);
			recipe.AddTile(TileID.Anvils);

			recipe.SetResult(this);
			recipe.AddRecipe();



		}






	}
}
