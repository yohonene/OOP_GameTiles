using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    public class Tile
    {
        private String _icon = "T";
        private String name = "Tile";
        public String Icon { get => _icon; set{ _icon = value;} }
        public String Name { get => name; set { name = value; } }

        private int row;
        private int col;
        

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
            }
        }

        public ConsoleColor Colour = ConsoleColor.Gray;


        /* Return tile position when prompted ToString
         */
        public override string ToString()
        {
            return name;
        }

        /* Returns icon
        */
        public string getIcon()
        {
            return _icon;
        }
    }
}
