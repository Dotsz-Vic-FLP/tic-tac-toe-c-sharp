// https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-6.0
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
// https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=net-8.0


App app = new App();
app.Run();


internal class App
{
    List<List<string>> gameBoard = new List<List<string>>()
    {
        new List<string> { UI.BLANK, UI.BLANK, UI.BLANK }, 
        new List<string> { UI.BLANK, UI.BLANK, UI.BLANK }, 
        new List<string> { UI.BLANK, UI.BLANK, UI.BLANK }
    };
    
    // class to run the application
    public void Run()
    {
        Util.Print("Tic-Tac-Toe Game:\n", ConsoleColor.DarkBlue);
        
        // gameBoard = InitializeGameBoard(gameBoard); // initialize the game board

        Util.Print(UI.GenerateBoard(gameBoard)); // show the board initially
        
        int turn = 1;
        while (true)
        {
            if (turn % 2 == 0)
            {
                Util.Print("\n \nPlayer 2's turn (o)\nValid format(<x>,<y>)\n", ConsoleColor.DarkGreen);
                (gameBoard, turn) = ValidateInput("O", gameBoard, turn); // returns an updated board and the current turn
                Util.Print(UI.GenerateBoard(gameBoard)); // show the updated board
            }
            else
            {   
                Util.Print("\n \nPlayer 1's turn (x)\nValid format(<x>,<y>)\n", ConsoleColor.DarkMagenta);
                (gameBoard, turn) = ValidateInput("X", gameBoard, turn); // returns an updated board and the current turn
                Util.Print(UI.GenerateBoard(gameBoard)); // show the updated board
            }
            if (turn > 9) // check if the game is a draw
            {
                Util.Print("Game Over! It's a draw!", ConsoleColor.DarkRed);
                break;
            }
            // exit condition
            // check if the game is over
        }
    }

/**
 * Gets the input on which coordinate the player would like to choose
 * <param name="input"> The input of the player </param>
 * <param name="gameBoard"> The game board </param>
 * <param name="currentTurn"> The current turn </param>
 * <returns> The updated game board and the current turn </returns>
 */
    public (List<List<string>>, int currentTurn) ValidateInput(string input, List<List<string>> gameBoard, int currentTurn)
    {
        // List<int> coordinates = new List<int>();
        List<int> coordinates;
        char[] delimiters = [' ', ',' , ':'];
        try
        { // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=net-8.0
            // check if the input is valid
            coordinates = Console.ReadLine().Split(delimiters).Select(Int32.Parse).ToList();
            if( coordinates.Count == 2 && Util.IsWithinBounds(coordinates) && gameBoard[coordinates[0]][coordinates[1]] == UI.BLANK)
            {
                gameBoard[coordinates[0]-1][coordinates[1]-1] = input;
                return (gameBoard, currentTurn + 1); // return the updated game board and the next turn
            }
            
            // if the input is invalid then print an error message and return the game board as is 
            Util.Print("Invalid input! Please try again.\n", ConsoleColor.DarkRed);
            return (gameBoard, currentTurn); // return the game board as is
        }
        catch (Exception e)
        {
            Util.Print( e.ToString(), ConsoleColor.DarkRed);
            return (gameBoard, currentTurn); // return the game board as is
        }
        
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
    
    /**
     * Checks if the coordinates are within bounds
     * <param name="coordinates"> The coordinates to be checked </param>
     */
    public static bool IsWithinBounds(List<int> coordinates) // helper function to check if the coordinates are within bounds
    {
        foreach (var coordinate in coordinates)
        {
            if (coordinate < 1 || coordinate > 3)
            {
                return false;
            }
        }
        return true;
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







