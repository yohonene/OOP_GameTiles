using OOP_Board_Test.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOP_Board_Test
{
    internal class Player : Tile
    {
        private Board brd;

        private String _icon = "■";
        private ConsoleColor _colour = ConsoleColor.Green;
        private int delta = 1;
        private bool displayInventory { get; set; }
        public int HP;
        public Tile standingOn { get; set; }
        public String interactText { get; set; }
        public String holdingItem { get; set; }
        private int count = -1;

        public List<Items> Inventory = new List<Items>();
        public List<Items> Tools = new List<Items>();

        public Player()
        {
            this.Icon = _icon;
            this.Colour = _colour;
            this.standingOn = null;
            this.holdingItem = "No Tool";
            HP = 10;
        }

        /* Method to handle player movement via arrow keys.
         * If Enter is pressed, Interact() method is called.
         */

        public void movement()
        {
            //Important maximum params
            int[] limits = brd.boardParams();
            int MAX_ROW = limits[0];
            int MAX_COL = limits[1];


            ConsoleKeyInfo key;
            key = Console.ReadKey(true);


            //Corresponding keys move delta in 4 possible directions
            //If potential movement exceeds board limits, will be ignored
            switch(key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (this.Row + 1 < MAX_ROW) { this.Row += delta; }
                    break;
                case ConsoleKey.UpArrow:
                    if (this.Row > 0) { this.Row -= delta; }
                    break;
                case ConsoleKey.RightArrow:
                    if (this.Col + 1 < MAX_COL) { this.Col += delta; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (this.Col > 0) { this.Col -= delta; }
                    break;
                case ConsoleKey.Enter: //Interacts with Tile below character.
                    Interact();
                    break;
                case ConsoleKey.I: //Inventory
                    displayInventory = true; 
                    break;
                case ConsoleKey.Q:
                    this.holdingItem = Tools.First().Name;
                    Tools.Reverse();
                    this.interactText = "You switch to your Pickaxe";
                    break;

            }
        }
        /* Disables overworld movement, allows user to move around in Crafting UI
         */
        public void craftingMovement(List<Items> recipes, CraftUI cui)
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            //Clear event text
            cui.eventText = null;


            switch (key.Key)
            {
                case ConsoleKey.I: 
                     //UI checks each loop if this is true and prints inventory
                    displayInventory = false;
                    break;

                case ConsoleKey.RightArrow:
                    count++;
                    int max_size = recipes.Count();
                    if (count == max_size) { count = 0; recipes[max_size-1].Name = recipes.Last().Name.Remove(0, 1);  } //Remove indicator from last item
                    Debug.WriteLine(count);
                    if (count < max_size) //This cycles through the recipe list, adding a > to indicate what is selected
                    {
                        //Add indicator to new element
                        addIndicator(recipes, count);
                        //Remove indicator from previous value
                        if (count > 0){recipes[count - 1].Name = recipes[count-1].Name.Remove(0, 1);}
                    }
                    break;
                case ConsoleKey.Enter:
                    CraftUI crafting = new CraftUI();
                    var casted_item = (Crafted_Item)recipes[count]; //Cast item to become crafted_item
                    if (crafting.checkIfCraftable(Inventory, casted_item))  //If user has required items to craft add to inventory
                    {
                        //Add Item to tool inventory and remove indicator
                        String item = recipes[count].Name.Remove(0, 1);
                        Crafted_Item item_obj = new(item);
                        Tools.Add(item_obj);
                        //Set error text for to success
                        cui.eventText = $"{item} crafted.";
                        cui.eventColour= ConsoleColor.Green;
                    } else
                    {
                        //Update error text for CraftingUI
                        cui.eventText = "Insufficient Materials";
                        cui.eventColour = ConsoleColor.Red;
                    }
                    break;
            }

        }
        /*Helps clean up code, adds indicator to first position of string
         */ 
        private void addIndicator(List<Items> recipes, int count)
        {
            String original_string = recipes[count].Name;
            String new_string = ">" + original_string;
            recipes[count].Name = new_string;
        }

        public bool checkInventory()
        {
            if (displayInventory == true)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /* Interacts with tile, Enter Key; UI prints out if interact is sucessfull.
         */
        public void Interact()
        {
            Dirt dirt_tile = new Dirt(this.Row, this.Col);
            Items item_gathered; 

            if (this.standingOn.Name == "Iron")
            {
                if(this.holdingItem == "Pickaxe")
                {
                    //Update what tile you are standing on
                    this.standingOn = dirt_tile;
                    brd.changeOldTile(this); //Changes Tile to a specified tile (Default is Dirt)
                    item_gathered = new Iron_Ore();
                    this.interactText = item_gathered.interact_text;
                    Inventory.Add(item_gathered); //Add Item to Inventory

                } else
                {
                    this.interactText = "You need to equip a Pick";
                }
            } 
            else if (this.standingOn.Name == "Stick")
            {
                this.standingOn = dirt_tile;
                brd.changeOldTile(this);
                item_gathered = new Item_Stick();
                this.interactText = item_gathered.interact_text;
                Inventory.Add(item_gathered);
            }
            else if (this.standingOn.Name == "Tree")
            {
                if (this.holdingItem == "Axe")
                {
                    this.standingOn = dirt_tile;
                    brd.changeOldTile(this);
                    item_gathered = new Item_Wood();
                    this.interactText = item_gathered.interact_text;
                    Inventory.Add(item_gathered);
                } else
                {
                    this.interactText = "You need to equip an Axe";
                }
            }
            else
            {
                this.interactText = null;
            }

        }

        /* Handles starting positon gen of character
         */ 
        public Player startPosition(Board board)
        {
            //Update Player Board Variable so every method can access.
            brd = board;
            int[] board_size = brd.boardParams();
            this.Row = board_size[0] / 2;
            this.Col = board_size[1] / 2;
            //Divide by half so its in the middle.
            return this;
        }

    }
}
