using QuizPleaser.Models;

namespace QuizPleaser.Services;

public class QuizService : IQuizService
{
    private readonly List<Question> _questions;
    private readonly List<Theme> _themes;

    public QuizService(IYamlLoader loader)
    {
        _questions = loader.LoadQuestions("Data/questions.yaml");
        _themes = loader.LoadThemes("Data/themes.yaml");
    }
    
    public List<Question> GetAvailableQuestions()
    {
        return _questions;
    }

    public bool IsAnswerCorrect(Question question, int userAnswerIndex)
    {
        return question.CorrectAnswerIndex == userAnswerIndex;
    }
}