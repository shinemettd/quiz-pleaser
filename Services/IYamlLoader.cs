using QuizPleaser.Models;

namespace QuizPleaser.Services;

public interface IYamlLoader
{
    List<Theme> LoadThemes(string path);
    List<Question> LoadQuestions(string path);
}