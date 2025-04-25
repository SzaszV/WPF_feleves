using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
    using WPF_feleves.Models;
namespace WPF_feleves.ViewModels
{
   

public class EditRecipeViewModel
    {
        private readonly Recipe _originalRecipe;
        private readonly Action<Recipe> _updateRecipeAction;

        public ICommand AddIngredientCommand { get; }
        public ICommand RemoveIngredientCommand { get; }
        public ICommand SaveCommand { get; }
        public string? selectedIngredient { get; set; }
        public EditRecipeViewModel(Recipe selectedRecipe, Action<Recipe> updateRecipeAction)
        {
            _originalRecipe = selectedRecipe;
            _updateRecipeAction = updateRecipeAction;

            AddIngredientCommand = new RelayCommand(AddIngredient, CanAddIngredient);
            RemoveIngredientCommand = new RelayCommand(RemoveIngredient, CanAddIngredient);

            Name = selectedRecipe.Name;
            Instructions = selectedRecipe.Instructions;
            Ingredients = new ObservableCollection<string?>(selectedRecipe.Ingredients);

            EditRecipeCommand = new RelayCommand(EditRecipe, CanEditRecipe);
            SaveCommand = new RelayCommand(SaveRecipe, CanSaveRecipe);
        }

        public ICommand EditRecipeCommand { get; }
        public string? Name { get; set; }
        public string? Ingredient { get; set; }
        public ObservableCollection<string?> Ingredients { get; set; } = new ObservableCollection<string?>();
        public string? Instructions { get; set; }

        private void EditRecipe(object? parameter)
        {
            if (parameter is Recipe recipeToUpdate)
            {
                recipeToUpdate.Name = Name;
                recipeToUpdate.Instructions = Instructions;
                recipeToUpdate.Ingredients = new ObservableCollection<string?>(Ingredients);
            }
        }

        private bool CanEditRecipe(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Name) && Ingredients.Count > 0;
        }
        private void SaveRecipe(object? parameter)
        {
            var updatedRecipe = new Recipe
            {
                Name = Name,
                Ingredients = Ingredients.Select(ingredient => ingredient?.Trim()).ToList(),
                Instructions = Instructions
            };
            _updateRecipeAction(updatedRecipe);
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        private bool CanSaveRecipe(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Name) && Ingredients.Count > 0;
        }
        private void AddIngredient(object? parameter)
        {
            if (!string.IsNullOrWhiteSpace(selectedIngredient))
            {
                Ingredients.Add(selectedIngredient.Trim());
                selectedIngredient = string.Empty;
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
