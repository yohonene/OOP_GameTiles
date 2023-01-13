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
    }
}
