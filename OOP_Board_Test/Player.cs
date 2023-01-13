using OOP_Board_Test.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public List<String> Inventory = new List<String>();

        public Player()
        {
            this.Icon = _icon;
            this.Colour = _colour;
            this.standingOn = null;
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
                    if (displayInventory == true) {  displayInventory = false; } //Turn off if pressed again
                    else
                    {
                        //UI checks each loop if this is true and prints inventory
                        displayInventory = true;
                    } 
                    break;

            }
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
            if(this.standingOn.Name == "Iron")
            {
                //When Iron is mined, will be changed to DIRT tile.
                Dirt dirt_tile = new Dirt(this.Row, this.Col);
                this.interactText = "You Mine Iron";
                this.standingOn = dirt_tile;
                brd.changeOldTile(this); //Changes Tile to a specified tile (Default is Dirt)
                //Add Item to Inventory
                Inventory.Add("Iron");
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
