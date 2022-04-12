using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tietank.Items.Loots
{
	public class HollowedEthos : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void's Ethos");
			Tooltip.SetDefault("'Mysterious purple flame keeps on blazing, MOM!!!'\nIt flashes ceaselessly");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 5));
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 50;
			item.maxStack = 999;
			item.rare = ItemRarityID.Purple;
			item.value = Item.sellPrice(silver: 61);
		}


		
	}

	
}