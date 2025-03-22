using QuizPleaser.Models;

namespace QuizPleaser.Services;

public interface IQuizService
{
    List<Question> GetAvailableQuestions();
    bool IsAnswerCorrect(Question question, int userAnswerIndex);
}