using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace MoreWeapons
{
    public class ReciptsModify: ModSystem
    {

        public override void AddRecipes()
        {
            Recipe recipe = Mod.CreateRecipe(ItemID.TargetDummy);
            recipe.AddIngredient(ItemID.Wood, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
