using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    internal class CraftUI
    {
        public CraftUI()
        {
            recipies.Add("Shovel");
            recipies.Add("Pan");
            recipies.Add("Axe");
        }
        private List<String> recipies = new List<String>();
        private String selectedItem;

        public List<String> printCraftingUI(List<String> inventory)
        {
            printCrafting();
            printInventory(inventory);
            return recipies;
        }

        /* Prints out the crafting section, user can select what recipe
        */  
        private void printCrafting()
        {
            Console.WriteLine("\n    ----------Crafting---------\n");
            Console.Write("\t");
            printList(recipies);
        }

        /* Prints out the inventory
        */
        private void printInventory(List<String> inventory)
        {
            Console.WriteLine("\n    ---------Inventory---------");          
            printList(inventory, "►");

        }

        /* Prints a given list, user can supply marker to be placed before text if needed
         */
        private void printList(List<String> inventory, String optional_marker = "")
        {
            int counter = 0;
            foreach (String item in inventory)
            {
                if (counter > 4) { Console.WriteLine(); counter = 0; } //Word Wrap
                Console.Write(optional_marker + item + "\t");
                counter++;
            }
        }
    }
}
