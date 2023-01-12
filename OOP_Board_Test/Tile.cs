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
        public String Icon { get => _icon; set{ _icon = value;} }

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
            return "Row: " + Row + " Column: " + Col;
        }

        /* Returns icon
        */
        public string getIcon()
        {
            return _icon;
        }
    }
}
