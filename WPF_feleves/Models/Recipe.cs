namespace WPF_feleves.Models
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new List<string>();
        }

        public string Name { get; set; }
        public ICollection<string> Ingredients { get; set; }
        public string Instructions { get; set; }
    }

}
