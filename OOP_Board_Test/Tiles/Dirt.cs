using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test.Tiles
{
    internal class Dirt : Tile
    {

        private string _icon = "▒";

        private ConsoleColor _colour = ConsoleColor.DarkRed;
        private String name = "Dirt";

        public Dirt(int row, int col)
        {
            Row = row;
            Col = col;
            Icon = _icon;
            Colour = _colour;
            Name = name;
        }




    }
}
