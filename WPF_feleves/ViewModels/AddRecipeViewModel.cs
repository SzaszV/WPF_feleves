using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF_feleves.Models;

namespace WPF_feleves.ViewModels
{
    public class AddRecipeViewModel
    {
        public ICommand AddRecipeCommand { get; set; }

        public string? Name { get; set; }

        public string? Ingredient { get; set; }
        //public ICollection< string?>? Ingredients { get; set; }
        public ObservableCollection<string?> Ingredients { get; set; } = new ObservableCollection<string?>();
        public string? Instructions { get; set; }
        public string? NewIngredient { get; set; }

        public ICommand AddIngredientCommand { get; }
        public ICommand RemoveIngredientCommand { get; }
        public AddRecipeViewModel()
        {
            AddRecipeCommand = new RelayCommand(AddRecipe, CanAddRecipe);
            AddIngredientCommand = new RelayCommand(AddIngredient, CanAddIngredient);
            RemoveIngredientCommand = new RelayCommand(RemoveIngredient, CanAddIngredient);
        }
        private bool CanAddRecipe(object obj)
        {
            return true;
        }
        private void AddRecipe(object obj)
        {
            var trimmedIngredients = Ingredients.Select(ingredient => ingredient?.Trim()).ToList(); // Create a trimmed copy
            RecipeManager.AddRecipe(new Recipe() { Name = Name, Ingredients = trimmedIngredients, Instructions = Instructions });
        }
      /*  private void AddRecipe(object obj)
        {
            foreach (var ingredient in Ingredients)
            {
                Ingredients.Add(ingredient.Trim());
            }
            RecipeManager.AddRecipe(new Recipe() { Name = Name, Ingredients = Ingredients, Instructions = Instructions });
        }*/
        private void AddIngredient(object? parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewIngredient))
            {
                Ingredients.Add(NewIngredient.Trim());
                NewIngredient = string.Empty;
            }
        }
        private bool CanAddIngredient(object? parameter)
        {
            return true;
        }
        private void RemoveIngredient(object? parameter)
        {
            if (parameter is string ingredient && Ingredients.Contains(ingredient))
            {
                Ingredients.Remove(ingredient);
            }
        }
    }
}
