using OOP_Board_Test;

internal class Program
{
    private static void Main(string[] args)
    {


        //Connect to relevant classes
        UI ui = new UI();
        Player plr = new Player();
        Board brd = new Board();

        //Hides blinking underscore
        Console.CursorVisible = false;

        //Initial gen for board
        brd.initialGen(plr);

        //Game loop
        do
        {
            brd.generateBoard(plr); //Update terrain and player
            ui.printUI(plr); //Print Extra UI features
            plr.movement(); //Parse player on what to do next

        } while (true);
        

    }

}