using System.Drawing;
using System.Collections.Generic;

static void main(string[] args)
{ // entry point
    App app = new App();
    app.run();
}

class App
{ // class to run the application
    public void run()
    {

        Util.Print("Tic-Tac-Toe Game:", ConsoleColor.DarkBlue);

        // call the function to show the board

        List<List<string>> board = InitializeList();

        int turn = 1;
        while (true)
        {

            Util.GenerateGrid(board);



            // exit condition
            // System.Environment.Exit(0);
        }

    }


    public static List<List<string>> InitializeList ()
    {
        List<string> row = new List<string>();
        List<List<string>> tikTakToe = new List<List<string>>();
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
    }
}

class getInput
{
    
}

