using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Tietank.Items.Loots
{


	
		public class CrystalMeth : ModItem
		{

			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Crystal Meth");
            Tooltip.SetDefault("Say my name.\nGive you pleasure but destroy your life.");


			}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 26;
			item.value = Item.sellPrice(gold: 2);
			item.maxStack = 999;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 15;
			item.useTime = 15;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.buffType = BuffID.Lovestruck;
			item.buffTime = 900;

		}
        public override void OnConsumeItem(Player player)
        {
			player.AddBuff(BuffID.Slow, 900);
			player.AddBuff(BuffID.OnFire, 900);
			player.AddBuff(BuffID.Confused, 900);
			player.AddBuff(BuffID.Bleeding, 900);
			player.AddBuff(BuffID.Weak, 900);
			player.AddBuff(BuffID.Poisoned, 900);
			player.AddBuff(BuffID.Ichor, 900);
			player.AddBuff(BuffID.Frozen, 900);
			player.AddBuff(BuffID.PotionSickness, 900);
			player.AddBuff(BuffID.ManaSickness, 900);
			player.AddBuff(BuffID.ChaosState, 900);
			player.AddBuff(BuffID.Suffocation, 900);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vitamins, 10);
			recipe.AddIngredient(ItemID.GreaterHealingPotion, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddIngredient(ItemID.PixieDust, 50);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}



	}
}
