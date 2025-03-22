namespace QuizPleaser.Models;

public class Question
{
    public string ThemeId { get; set; } = null!;
    public string Text { get; set; } = null!;
    public List<string> Answers { get; set; } = new();
    public int CorrectAnswerIndex { get; set; }
    
    public string GetHash()
    {
        var combined = $"{Text.Trim()}|{string.Join("|", Answers)}";
        using var sha = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(combined);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}