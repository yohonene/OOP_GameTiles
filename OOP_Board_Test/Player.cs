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
        private String _icon = "■";

        private ConsoleColor _colour = ConsoleColor.Green;
        private int delta = 1;
        public int HP;

        public Player()
        {
            this.Icon = _icon;
            this.Colour = _colour;
            HP = 10;
        }

        /* Method to handle player movement via arrow keys. 
         */

        public void movement()
        {
            //Board class connection and important maximum params
            Board brd = new Board();
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

            }
        }

        /* Handles starting positon gen of character
         */ 
        public Player startPosition()
        {
            //Acquire board size so player can be accurately placed
            Board brd = new Board();
            int[] board_size = brd.boardParams();
            this.Row = board_size[0] / 2;
            this.Col = board_size[1] / 2;
            //Divide by half so its in the middle.
            return this;
        }

    }
}
