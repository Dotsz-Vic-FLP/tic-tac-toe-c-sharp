

App app = new App();
app.Run();


internal class App
{ // class to run the application
    public void Run()
    {

        Util.Print("Tic-Tac-Toe Game:", ConsoleColor.DarkBlue);

        // call the function to show the board

        List<List<string>> board = InitializeList();

        int turn = 1;
        while (true)
        {

            Util.GenerateGrid(board);
            
            if(turn%2 == 0)
            {
                Util.Print("Player 2's turn (o)", ConsoleColor.DarkGreen);
                
                // call get input function
                // update the board
                // check for win condition
                // check for draw condition
                // increment turn
                
            }
            else
            {
                Util.Print("Player 1's turn (x) ", ConsoleColor.DarkGreen);
                // call get input function
                // update the board
                // check for win condition
                // check for draw condition
                // increment turn
                
            }
            
            
            // exit condition
            // System.Environment.Exit(0);
        }

    }

    
    private static List<List<string>> InitializeList ()
    {
        List<string> row = [];
        List<List<string>> tikTakToe = [[]];
        for(int i = 0; i <= 3; i++ )
        {
            row.Add(UI.BLANK);
        }
        for(int i = 0; i <= 3; i++ )
        {
            tikTakToe.Add(row);
        }
        return tikTakToe;
    }

}



/**
 * UI class
 * 
 * This class contains all the UI elements
 */
class UI
{
    /**
     * Generates a bounding line
     * <param name="length"> The length of the line </param>
     */
    public static string DividerLine(int length)
    {

        string result = string.Empty;
        for (int i = 0; i <= length; i++)
        {
            result += DIVIDER_UNIT;
        }

        return result;
    }
    public static readonly string DIVIDER_UNIT = "+";
    public static readonly string BLANK = "_"; //Readonly string what is this??? // readonly means final; the value doesn't change
}

/**
 * Util class
 * 
 * This class contains all the utility functions
 */
class Util
{
    public static void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
    }
    
    public static void Print(string message)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(message);
    }

    public static string GenerateGrid(List<List<string>> grid)
    {
        Print(UI.DividerLine(grid.Count));
        foreach (List<string> row in grid)
        {
            foreach (string item in row)
            {
                Print(item);
            }
        }
        
        // return what?
        return "";
    }
}



