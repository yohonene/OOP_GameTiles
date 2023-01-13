using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    internal class UI
    {

        public UI() { }

        public void printUI(Player plr)
        {
            //Print UI elements after board has been printed
            Console.WriteLine("\n HP: " + plr.HP);
        }

        public void topBorder()
        {
            Console.Write("╔════════════════════╗");
        }
        public void bottomBorder() 
        {
            Console.Write("╚════════════════════╝");
        }
        public bool leftBorder(bool border_left) {
            if (border_left == false) 
            { 
                Console.ForegroundColor = ConsoleColor.Gray; Console.Write("║" + " "); border_left = true;
                return true;
            }
            return false;
        }
        public void rightBorder(bool border_right) {
            if (border_right == false) 
            { 
                Console.Write(" ║" + "\n"); 
            }
            else
            {
                Console.WriteLine(); // New Line
            }
        }
    }
}
