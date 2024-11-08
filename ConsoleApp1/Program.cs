// https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-6.0
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
// https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=net-8.0
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

App app = new App();
app.Run();


internal class App
{
    // class to run the application
    public void Run()
    {

        Util.Print("Tic-Tac-Toe Game:\n", ConsoleColor.DarkBlue);

        // call the function to show the board
        List<String> row = InitializeListString();
        List<List<string>> board = InitializeGameBoard(row);

        int turn = 1;
        while (true)
        {

            Util.Print(UI.GenerateBoard(board));

            if (turn % 2 == 0)
            {
                Util.Print("Player 2's turn (o)\n Valid format(\'x,y\')", ConsoleColor.DarkGreen);

                ValidateInput("O", board);
                // call get input function
                // update the board
                // check for win condition
                // check for draw condition
                // increment turn

            }
            else
            {
                Util.Print("Player 1's turn (x)\n", ConsoleColor.DarkMagenta);
                ValidateInput("X", board);
                // update the board
                // check for win condition
                // check for draw condition
                // increment turn

            }

            if (turn > 9)
            {
                Util.Print("Game Over! It's a draw!", ConsoleColor.DarkRed);
                break;
            }

            // exit condition
            turn++;
        }

    }

/**
 * Gets the input on which coordinate the player would like to choose
 *
 */


    public List<int> ValidateInput(string input, List<List<string>> gameBoard)
    {
        List<int> coordinates = new List<int>();
        char[] delimiters = { ' ', ',' , ':'};

        try
        { // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=net-8.0
            // check if the input is valid
            coordinates = Console.ReadLine().Split(delimiters).Select(Int32.Parse).ToList();
            if( coordinates.Count == 2 && coordinates[0] < 3 && coordinates[1] > 3 )
            {
                gameBoard[coordinates[0]][coordinates[1]] = input;

            }



        }
        catch (Exception e)
        {
            Util.Print("Invalid input. Please enter a valid input.\n", ConsoleColor.DarkRed);

        }

        return null; // temporary
    }



    private static List<List<string>> InitializeGameBoard (List<string> row)
    {
        List<List<string>> gameBoard = [];
        for(int i = 0; i < 3; i++ )
        {
            gameBoard.Add(row); // add 3 rows to the gameBoard
        }
        return gameBoard;
    }

    private static List<string> InitializeListString()
    {
        List<string> row = []; // initialize an empty list for row
        for(int i = 0; i < 3; i++ )
        {
            row.Add(UI.BLANK);// add 3 blanks to the row
        }

        return row;
    }

}







/**
 * Util class
 *
 * This class contains all the utility functions
 */
class Util
{


    /**
     * Prints a message
     * <param name="message"> The message to be printed </param>
     * <param name="color"> The color of the message </param>
     */
    public static void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
    }

    /**
     * Prints a message
     * <param name="message"> The message to be printed </param>
     */
    public static void Print(string message)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(message);
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
         * idk what it did before but now it Grabs the entire Board and turns it into a Visual so that the user
         * may see what posistions are open and closed
         * <param name=gameBoard> all of the possible positions for the player to use</param>
         */
        public static string GenerateBoard(List<List<string>> gameBoard)
        {
            string result = "#######\n";
            foreach (var row in gameBoard)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 2)
                    {
                        result += $"{DIVIDER_UNIT}{row[i]}{DIVIDER_UNIT}";
                    }
                    else
                    {
                        result += $"{DIVIDER_UNIT}{row[i]}";
                    }
                }

                result += "\n";
            }

            result += "#######";
            return result;
        }

        // Constants
        private static readonly string DIVIDER_UNIT = "#";
        public static readonly string BLANK = "_";
}







