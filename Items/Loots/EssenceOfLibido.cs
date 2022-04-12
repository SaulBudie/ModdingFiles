using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Tietank.Items.Loots
{


	
	public class EssenceOfLibido : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence Of Libido");
			Tooltip.SetDefault("'So basically, sex?'");

		}

		public override void SetDefaults()
		{
			
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(gold: 5);
			item.maxStack = 999;
			item.rare = ItemRarityID.Lime;

		}
		


	}
}
