using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    internal class Board
    {
        public const int MAX_ROW = 10;
        public const int MAX_COL = 18;

        //All tiles will be generated on this
        private List<Tile> board = new List<Tile>();
        //Holds previous tiles that will be redrawn once Mob/Player has left
        private List<Tile> old_tile = new List<Tile>();

        public Board() 
        {
        }

        /* Returns board parameters
         */ 
        public int[] boardParams()
        {
            int[] param = new int[] { MAX_ROW, MAX_COL };
            return param;
        }

        public void initialGen(Player plr)
        {
            //Randomly assign tile types to coordinate
            board = coordTileCouple();

            //Coordinates stored in plr object
            plr.startPosition();
        }

        /* Generates a board if given appropriate tile list.
         */
        public void generateBoard(Player plr)
        {
            //UI class will print elements outside of border
            UI ui = new UI();
            //Clear to make screen cleaner
            Console.Clear();
            //Replace previous player object position with old tile (if moved)
            if (old_tile.Count > 0) { placeOldTile(plr); }
            //Replace tile object with player obj to be drawn
            placePlayer(plr);

            //Top of Border
            ui.topBorder();

            //This will allow the list to print out all tiles and not exceed array size.
            int count = -1; 

            //Bools to check if border has been printed
            bool border_right = true;
            bool border_left;

            for (int x = 0; x < board.Last().Row; x++) //Last entry will have the largest column or row
            {
                //Reset border_left bool so that it can be printed once per row
                border_left = false;
                //Right border must ignore being printed ONCE
                ui.rightBorder(border_right);

                count++;
                for (int y = 0; y < board.Last().Col; y++) 
                {
                    //Left side of border
                    if (ui.leftBorder(border_left))
                    {
                        border_right = false;
                        border_left = true;
                    }
                   
                    //Set tile colour to whatever is specified
                    Console.ForegroundColor = board[count].Colour;
                    //Print tile's icon
                    Console.Write(board[count].getIcon());
                    count++;
                }
            }
            //Finish printing rest of border (otherwise there is a gap)
            ui.rightBorder(border_right);
            ui.bottomBorder();

            //Reset text colours
            Console.ForegroundColor = ConsoleColor.Gray;

            //Print Extra UI elements after board has been updated
            ui.printUI(plr);


        }
        private List<Tile> coordTileCouple()
        {
            //Make list of tiles to simulate board

            for (int x = 0; x < MAX_ROW + 1; x++)
            {
                for (int y = 0; y < MAX_COL + 1; y++)
                {
                    Random ran = new Random();

                    double val = ran.NextDouble();

                    if (val > 0.3)
                    {
                        Grass grass_tile = new Grass(x, y);
                        board.Add(grass_tile);
                    }
                    else
                    {
                        Dirt dirt_tile = new Dirt(x, y);
                        board.Add(dirt_tile);
                    }
                }
            }
            return board;
        }

        private void placeOldTile(Player plr)
        {
            int index_spotTaken = board.IndexOf(plr);
            board[index_spotTaken] = old_tile[0];
        }

        /* After terrain has been drawn, player will be placed.
         */
        private void placePlayer(Player plr)
        {
            int player_row = plr.Row;
            int player_col = plr.Col;
            //Replace object which shares same coordinates as object - Sets old_tile list
                //Note: Creates an IEnumerable object if not converted to a list
            old_tile = board.Where(i => i.Row == player_row && i.Col == player_col).ToList(); 
            //First object (only object) in list has index stored
            int index_OldTile = board.IndexOf(old_tile.First());
            board[index_OldTile] = plr; 
        }
    }
}
