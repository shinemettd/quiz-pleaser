namespace QuizPleaser.Utils;

public static class ConsoleUtil
{
    public static void TypeLine()
    {
        Console.WriteLine();
    }
    
    public static void TypeLine(string text, int delayMs = 10)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
        Console.WriteLine();
    }

    public static void Type(string text, int delayMs = 10)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
    }
}