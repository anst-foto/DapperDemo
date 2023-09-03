namespace DapperDemo.App;

public static class CLI
{
    #region Base

    private static void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
    
    private static void PrintLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static string? Input(string message)
    {
        Print(message, ConsoleColor.Magenta);
        return Console.ReadLine();
    }

    #endregion

    #region Input

    public static string? InputString(string message)
    {
        return Input(message);
    }

    public static int InputNumber(string message)
    {
        return Convert.ToInt32(Input(message));
    }

    #endregion

    #region Print

    public static void PrintError(string message)
    {
        PrintLine(message, ConsoleColor.Red);
    }

    public static void PrintInfo(string message)
    {
        PrintLine(message, ConsoleColor.Green);
    }

    #endregion
}