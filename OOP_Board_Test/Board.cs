using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    internal class Board
    {
        const int MAX_ROW = 4;
        const int MAX_COL = 6;

        public Board() { }

        /* Generates a board if given appropriate tile list.
         */
        public void generateBoard()
        {
            //Randomly assign tile types to coordinate
            List<Tile> board = coordTileCouple();

            int count = -1; //This will allow the list to print out all tiles.
            for (int x = 0; x < board.Last().Row; x++) //Last entry will have the largest column or row
            {
                Console.WriteLine(); //New Line
                count++;
                for (int y = 0; y < board.Last().Col; y++) 
                {
                    //Print tile's icon
                    Console.Write(board[count].getIcon());
                    count++;
                }
            }
        }
        private List<Tile> coordTileCouple()
        {
            //Make list of tiles to simulate board
            List<Tile> board = new List<Tile>();

            for (int x = 0; x < MAX_ROW; x++)
            {
                for (int y = 0; y < MAX_COL; y++)
                {
                    Random ran = new Random();

                    double val = ran.NextDouble();

                    if (val > 0.5)
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
    }
}
