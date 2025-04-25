using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_feleves.Models;
using System.ComponentModel;
using System.Windows;
using WPF_feleves.Views;

namespace WPF_feleves.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

        public ICommand OpenAddRecipeWindowCommand { get; }
        public ICommand OpenEditRecipeWindowCommand { get; }
        public Recipe SelectedRecipe { get; set; } 


        public MainViewModel()
        {
            Recipes = RecipeManager.GetRecipes();
            OpenAddRecipeWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            OpenEditRecipeWindowCommand = new RelayCommand(OpenEditRecipeWindow, CanShowWindow);
        }
        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            AddRecipeWindow addRecipeWin = new AddRecipeWindow();
            addRecipeWin.Owner = mainWindow;
            addRecipeWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addRecipeWin.Show();
        }
        private void OpenEditRecipeWindow(object obj)
        {
            var mainWindow = obj as Window;
            if (SelectedRecipe != null)
            {
                EditRecipeWindow editWindow = new EditRecipeWindow(SelectedRecipe, UpdateRecipe);
                editWindow.ShowDialog();
            }
        }
        private void UpdateRecipe(Recipe updatedRecipe)
        {
            var index = Recipes.IndexOf(SelectedRecipe);
            if (index >= 0)
            {
                Recipes[index] = updatedRecipe;
            }
        }
    }
}
