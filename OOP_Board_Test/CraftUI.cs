using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    internal class CraftUI
    {
        public CraftUI() { }


        public void printCraftingUI(List<String> inventory)
        {
            printCrafting();
            printInventory(inventory);
        }

        private void printCrafting()
        {
            Console.WriteLine("\n    ----------Crafting---------\n");
        }

        private void printInventory(List<String> inventory)
        {
            Console.WriteLine("\n    ---------Inventory---------");
            //Counter to wordwrap inventory
            int counter = 0;
            foreach (String item in inventory)
            {
                if (counter > 4) { Console.WriteLine(); counter = 0; } //Word Wrap
                Console.Write(">" + item + "\t");
                counter++;
            }
        }
    }
}
