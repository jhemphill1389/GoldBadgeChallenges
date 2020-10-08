using _01_CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository

{
    public class MenuRepo
    {
        private readonly List<Menu> _menu = new List<Menu>();

        public List<Menu> GetItems()
        {
            return _menu;
        }

        public bool AddItem(Menu item)
        {
            int startCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > startCount);
            return wasAdded;
        }

        public bool DeleteItem(Menu item)
        {
            bool deleteResult = _menu.Remove(item);
            return deleteResult;
        }
    }
}