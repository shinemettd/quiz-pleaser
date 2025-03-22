using QuizPleaser.Models;

namespace QuizPleaser.Services;

public interface IResultService
{
    void SaveAnswer(UserAnswer answer);
    List<UserAnswer> LoadAll();
    bool HasAnswered(string questionHash);
    void ClearAll();
}