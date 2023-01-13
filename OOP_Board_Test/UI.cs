using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            String HealthText = "HP:" + plr.HP;
            //Wrap element in Border
            UIborder(HealthText);
        }

        /* Dynamically prints out top border based on how many columns there are.
         */
        public void topBorder()
        {
            Board board = new Board();
            int[] prms = board.boardParams();
            int cols = prms[1];
            String c = new string('═', cols);
            Console.Write($"╔═{c}═╗");
        }


        /* Dynamically prints out bottom border based on how many columns there are.
         */
        public void bottomBorder() 
        {
            Board board = new Board();
            int[] prms = board.boardParams();
            int cols = prms[1];
            String c = new string('═', cols);
            Console.Write($"╚═{c}═╝");
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

        /* Dynamically wraps text around with border based on text size
         */ 
        private void UIborder(String text)
        {
            //Find text length and optimize border to match
            int l = text.Length;
            //Create new string with size dictated by l
            String c = new String('─', l);
            Console.WriteLine($"\n┌{c}┐");
            Console.Write("│" + text + "│");
            Console.Write($"\n└{c}┘");
        }

    }
}
