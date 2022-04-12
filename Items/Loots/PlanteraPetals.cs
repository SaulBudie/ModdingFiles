using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Tietank.Items.Loots
{


	
	public class PlanteraPetals : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Petal");
			Tooltip.SetDefault("The petals look so fresh, as if it cannot become marcescent");

		}

		public override void SetDefaults()
		{ 
			item.width = 14;
			item.height = 20;
			item.value = Item.sellPrice(copper: 50);
			item.maxStack = 999;
			item.rare = ItemRarityID.Lime;
		}
		


	}
}
