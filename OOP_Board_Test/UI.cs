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

        private String border_text { get; set; }
        private String name { get; set; }


        public UI() { }

        public UI(string brd_text, string text)
        {
            this.border_text = brd_text;
            this.name = text;
        }

        //Publically accesible method that allows other methods to print important values onto the screen
        public void printUI(Player plr)
        {
            //Print UI elements after board has been printed
            String HealthText = "HP:" + plr.HP;
            String Test = "Test";
            String Yomama = "hii:3333333";
            String[] UIStrings = { HealthText, Test, Yomama };
            //Wrap elements in Border
            UItextBorder(UIStrings);
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

        /* Creates objects for UI class and returns them in a list.
         */
        private List<UI> UIobjectCreation(String[] text)
        {
            //List TO hold objects that will be sent to next method
            List<UI> uiOBJS = new List<UI>();

            foreach (String t in text)
            {
                //Find text length and optimize border to match
                int l = t.Length;
                //Create new string with size dictated by l
                String c = new String('─', l);
                //Create UI object to store values
                UI uiBOX = new UI(c, t);
                uiOBJS.Add(uiBOX);
            }
            return uiOBJS;
        }

        /* Wraps UI object in border with its corresponding text
         */
        private void UItextBorder(String[] strings)
        {
            //Retrieve list from method
            List<UI> objects = UIobjectCreation(strings);

            Console.WriteLine(); //New Line to avoid overlap

            //Print top layer of border for all elements
            foreach (UI o in objects)
            {
                Console.Write($"┌{o.border_text}┐"); //Print border top to match
            }
            //Space to place middle section
            Console.WriteLine();
            //Print middle section containg important text
            foreach (UI o in objects)
            {
                Console.Write("│" + o.name + "│");
            }
            Console.WriteLine();
            //Print bottom section
            foreach (UI o in objects)
            {
                Console.Write($"└{o.border_text}┘"); 
            }    
                        
        }

    }
}
