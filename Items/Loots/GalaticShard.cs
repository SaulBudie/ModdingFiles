using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Loots
{
	public class GalaticShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galatic Shard");
			Tooltip.SetDefault("'The artifacts of the Universe forged into one single item'");
			// ticksperframe, frameCount
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 25));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		// TODO -- Velocity Y smaller, post NewItem?
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 32;
			item.maxStack = 999;
			item.rare = ItemRarityID.Red;
			item.value = Item.sellPrice(silver: 80);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Lighting.AddLight(item.position, Color.White.ToVector3() * 1);
			
			
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 2);
			recipe.AddIngredient(ItemID.FragmentNebula, 2);
			recipe.AddIngredient(ItemID.FragmentVortex, 2);
			recipe.AddIngredient(ItemID.FragmentStardust, 2);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}

	
}