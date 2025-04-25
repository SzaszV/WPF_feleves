using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_feleves.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Recipe _selectedRecipe;
        public ObservableCollection<Recipe> Recipes { get; set; }

        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenEditRecipeWindowCommand { get; }

        public MainViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();
            OpenEditRecipeWindowCommand = new RelayCommand(OpenEditRecipeWindow);
        }

        private void OpenEditRecipeWindow()
        {
            if (SelectedRecipe != null)
            {
                var editRecipeWindow = new EditRecipeWindow(SelectedRecipe);
                if (editRecipeWindow.ShowDialog() == true)
                {
                    // Update the recipe in the collection  
                    var updatedRecipe = editRecipeWindow.UpdatedRecipe;
                    var index = Recipes.IndexOf(SelectedRecipe);
                    if (index >= 0)
                    {
                        Recipes[index] = updatedRecipe;
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
