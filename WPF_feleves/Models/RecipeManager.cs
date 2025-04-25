using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_feleves.Models
{
    class RecipeManager
    {
        public static ObservableCollection<Recipe> _DatabaseRecipes = new ObservableCollection<Recipe>() 
        { 
            new Recipe() { Ingredients = {"chicken", "egg", "flour", "breadcrumbs" }, Instructions="Wash the chicken. Dip it in flour, then put it in scrambled up eggs and finally put it in the breadcrumbs and time to fry it. Fry until golden brown then you can plate it. ", Name = "chicken nugget" }, 
            new Recipe() { Ingredients = { "milk", "egg", "flour", "soda", "sugar" }, Instructions="Take eggs, milk, floor and sugar and mix them until it's smooth liquid. Optionally you can put soda in the mixture to get your pancakes to be thin like crepes.", Name = "pancake" },
            new Recipe() { Ingredients = {"cocoa powder", "egg", "flour", "chocolate","sugar", "baking powder" }, Instructions="Mix the Cocoa powder with the flour, the baking powder and some sugar. After it's mixed heat up the chocolate and mix it with butter until smooth. Mix the two mixtures and put it in the oven for half an hour. Best eaten while hot/warm. ", Name = "brownie" },
            new Recipe() { Ingredients = {"ground beef", "onion", "bacon", "mayonaise", "lettuce", "tomatoe", "pickles", "kethcup", "burger" }, Instructions="Take the ground beef and make patties with it and bake/fry it. Take a burger, cut it in half, then put the ingredients you want inside to your heart's content. Usually made with the ingredients written here.", Name = "hamburger" },
            new Recipe() { Ingredients = {"salt", "egg" }, Instructions="Take a few eggs and put them in  the heated pan while pouring stir them and continue until they're cooked. Put a little salt on it for better taste.", Name = "scrambled eggs" } 
        };

        public static ObservableCollection<Recipe> GetRecipes()
        {
            return _DatabaseRecipes;
        }
        public static void AddRecipe(Recipe recipe)
        {
            _DatabaseRecipes.Add(recipe);
        }
    }
}
