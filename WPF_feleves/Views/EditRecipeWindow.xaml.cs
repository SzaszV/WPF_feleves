using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_feleves.Models;
using WPF_feleves.ViewModels;

namespace WPF_feleves.Views
{
    public partial class EditRecipeWindow : Window
    {
        public EditRecipeWindow(Recipe selectedRecipe, Action<Recipe> updateRecipeAction)
        {
            InitializeComponent();
            DataContext = new EditRecipeViewModel(selectedRecipe, updateRecipeAction);
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}

