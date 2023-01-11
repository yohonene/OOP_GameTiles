using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    public class Tile
    {
        private String _icon = "T";
        public String Icon { get => _icon; set{ _icon = value;} }


        private Boolean filled;
        public Boolean Filled
        {
            get { return filled; } 
            set { filled = value; }
        }

        public int Row { get; set; }
        public int Col { get; set; }


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
