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
            recipies.Add(new Crafted_Item("Pickaxe", "Stick", 3));
            recipies.Add(new Crafted_Item("Axe", "Iron", 5));
            recipies.Add(new Crafted_Item("Sword", "Iron", 8));
            recipies.Add(new Crafted_Item("Hoe", "Iron", 9));
        }
        private List<Items> recipies = new List<Items>();
        private String selectedItem;
        public String eventText { get; set; }
        public ConsoleColor eventColour { get; set; }

        public List<Items> printCraftingUI(List<Items> inventory, List<Items> tools)
        {
            printCrafting();
            printInventory(inventory);
            printInventory(tools, "Tools");
            UI ui = new UI();
            String[] EventStrings = { eventText };
            ui.UItextBorder(EventStrings, eventColour);
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
        private void printInventory(List<Items> inventory, String opt_text = "Inventory")
        {
            Console.WriteLine($"\n    ---------{opt_text}---------");          
            printList(inventory, "►");

        }

        /* Prints a given list, user can supply marker to be placed before text if needed
         */
        private void printList(List<Items> inventory, String optional_marker = "")
        {
            int counter = 0;
            foreach (Items item in inventory)
            {
                if (counter > 4) { Console.WriteLine(); counter = 0; } //Word Wrap
                Console.Write(optional_marker + item + "\t");
                counter++;
            }
        }

        /* Checks if a item can be crafted given a player inventory
         */
        public bool checkIfCraftable(List<Items> inv, Crafted_Item recipe_item)
        {
            //Lambda expression, find all objects in inventory holding this objects name
            var result = inv.FindAll(e => e.Name == recipe_item.Requirement);
            int amnt = result.Count();
            //Return true if player has equal to or more than required amount of items
            if (amnt >= recipe_item.Amount) 
            {
                //Remove objects consumed to craft
                foreach(Items item in result)
                {
                    inv.Remove(item);
                }
                return true; 
            } 
            else 
            {
                return false; 
            }
        }
    }
}
