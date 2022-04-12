using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Tietank.Items.Loots
{


	
	public class SymbolOfGlory : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbol Of Glory");
			Tooltip.SetDefault("How Glorious a Warrior");

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
