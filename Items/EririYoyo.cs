using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using MoreWeapons.Projectiles;
namespace MoreWeapons.Items {
	internal class EririYoyo : ModItem {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eriri Yoyo"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "英梨梨悠悠球");
			Tooltip.SetDefault("English Translations is Funny.");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "手动滑稽。");
		}
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.width = 40;
			Item.height = 40;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 2.5f;
			Item.damage = 9;
			Item.rare = ItemRarityID.White;

			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 1);
			Item.shoot = ModContent.ProjectileType<EririYoyoProjectile>();
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy };

		public override bool AllowPrefix(int pre)
		{
			// return false to make the game reroll the prefix

			// DON'T DO THIS BY ITSELF:
			// return false;
			// This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

			if (Array.IndexOf(unwantedPrefixes, pre) > -1)
			{
				// IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
				// Rolled a prefix we don't want, reroll
				return false;
			}
			// Don't reroll
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(ItemID.Wood).AddTile(TileID.WorkBenches).Register();
		}
	}
}
