using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    public class Menu
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MealNumber { get; set; }
        public string[] Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu(string name, string desc, int mealNumber, string[] ingredients, decimal price)

        {
            Name = name;
            Description = desc;
            MealNumber = mealNumber;
            Ingredients = ingredients;
            Price = price;
        }

        public Menu() { }
    }
}