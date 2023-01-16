using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Board_Test.Tiles
{
    internal class Tree : Tile
    {
        private string _icon = "╫";
        private ConsoleColor _colour = ConsoleColor.White;
        private String name = "Tree";


        public Tree(int row, int col)
        {
            Row = row;
            Col = col;
            Icon = _icon;
            Colour = _colour;
            Name = name;
        }
    }
}
