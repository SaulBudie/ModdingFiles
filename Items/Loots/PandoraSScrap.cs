using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Loots
{
	public class PandoraSScrap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora's Scrap");
			Tooltip.SetDefault("'The scrap is smokin tho'\nIt sparks on malice");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 50;
			item.maxStack = 999;
			item.rare = ItemRarityID.Lime;
			item.value = Item.sellPrice(silver: 60);
		}


		
	}

	
}