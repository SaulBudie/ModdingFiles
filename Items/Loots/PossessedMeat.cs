using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Tietank.Items.Loots
{


	
	public class PossessedMeat : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessed Meat");
			Tooltip.SetDefault("It just laying there, menacingly!");

		}

		public override void SetDefaults()
		{
			
			item.width = 20;
			item.height = 20;
			item.value = Item.sellPrice(silver: 1);
			item.maxStack = 999;
			item.rare = ItemRarityID.Orange;

		}
		


	}
}
