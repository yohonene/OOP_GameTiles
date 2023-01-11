using OOP_Board_Test;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        //Connect to Board Class
        Board brd = new Board();
        //Init the game board
        brd.generateBoard();

    }

}