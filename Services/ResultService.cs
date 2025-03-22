using System.Text.Json;
using QuizPleaser.Models;

namespace QuizPleaser.Services;

public class ResultService : IResultService
{
    private List<UserAnswer> _answers = [];
    
    private static readonly string ResultsFilePath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "Data", "results.json"
    );

    public ResultService()
    {
        var dir = Path.GetDirectoryName(ResultsFilePath);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (File.Exists(ResultsFilePath))
        {
            var json = File.ReadAllText(ResultsFilePath);
            _answers = JsonSerializer.Deserialize<List<UserAnswer>>(json) ?? [];
        }
    }

    public List<UserAnswer> LoadAll() => _answers;

    public bool HasAnswered(string questionHash) =>
        _answers.Any(a => a.QuestionHash == questionHash);

    public void SaveAnswer(UserAnswer answer)
    {
        _answers.RemoveAll(a => a.QuestionHash == answer.QuestionHash);
        _answers.Add(answer);

        var json = JsonSerializer.Serialize(_answers, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(ResultsFilePath, json);
    }

    public void ClearAll()
    {
        _answers.Clear();
        File.Delete(ResultsFilePath);
    }
}