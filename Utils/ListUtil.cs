namespace QuizPleaser.Utils;

public class ListUtil
{
    private static Random _random = new();

    public static void Shuffle<T>(IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = _random.Next(n + 1); 
            (list[n], list[k]) = (list[k], list[n]);
        }
    }
}