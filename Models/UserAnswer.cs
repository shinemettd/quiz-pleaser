namespace QuizPleaser.Models;

public class UserAnswer
{
    public string QuestionHash { get; set; } = "";
    public string ThemeId { get; set; } = "";
    public bool IsCorrect { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}