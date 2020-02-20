using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class Menu   
    {
        [Key]
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<string> ListOfIngredients { get; set; }

        public Menu() { }

        public Menu(int mealNumber, string mealName,string description,decimal price,ICollection<string> listOfIngredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            ListOfIngredients = listOfIngredients;
        }
    }

}
