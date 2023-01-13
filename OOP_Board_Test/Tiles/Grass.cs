using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test.Tiles
{
    internal class Grass : Tile
    {
        private string _icon = "░";
        private ConsoleColor _colour = ConsoleColor.DarkGreen;
        private String name = "Grass";


        public Grass(int row, int col)
        {
            Row = row;
            Col = col;
            Icon = _icon;
            Colour = _colour;
            Name = name;
        }

    }
}
