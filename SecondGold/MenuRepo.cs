using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondGold
{
    public class MenuRepo
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();

        //Return a list of all menu items.
        public List<Menu> GetFullMenu()
        {
            return _listOfMenuItems;
        }

        //Add an item to the menu list 
        public void AddMenuItem(Menu item)
        {
            if (LocateMenuItemById(item.MealNumber) == null )
            {
                _listOfMenuItems.Add(item);
            }
        }

        //locate object by ID
        public Menu LocateMenuItemById(int id)
        {
            foreach(Menu item in _listOfMenuItems)
            {
                if (item.MealNumber == id)
                {
                    return item;
                }
            }
            return null;
        }

        //Delete an item from the menu list 
        public void DeleteMenutItem(int id)
        {
           var menuItem = LocateMenuItemById(id);
            _listOfMenuItems.Remove(menuItem);
        }

        public bool AnotherDeleteMethod(int id)
        {
            var menuItem = LocateMenuItemById(id);
           return _listOfMenuItems.Remove(menuItem);
        }
    }
}
