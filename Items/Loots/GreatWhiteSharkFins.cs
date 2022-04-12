using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Tietank.Items.Loots
{


	
	public class GreatWhiteSharkFins : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Great White Shark Fin");
			Tooltip.SetDefault("Piscine and fishy yet pure and rare");

		}

		public override void SetDefaults()
		{ 
			item.width = 30;
			item.height = 50;
			item.value = Item.sellPrice(silver: 5);
			item.maxStack = 999;
			item.rare = ItemRarityID.Pink;
		}
		


	}
}
