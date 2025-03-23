using QuizPleaser.Services;
using QuizPleaser.Utils;

namespace QuizPleaser.Menu;

public class ShowResultsAction : IMenuAction
{
    private readonly ILocalizer _localizer;
    private readonly IResultService _results;
    private readonly IYamlLoader _yamlLoader;

    public ShowResultsAction(ILocalizer localizer, IResultService results, IYamlLoader yamlLoader)
    {
        _localizer = localizer;
        _results = results;
        _yamlLoader = yamlLoader;
    }
    
    public string Name => _localizer["menu.results"];
    
    public void Execute()
    {
        var answers = _results.LoadAll();

        if (!answers.Any())
        {
            Console.WriteLine(_localizer["results.no_data"]);
            Console.ReadKey();
            return;
        }

        var grouped = answers
            .GroupBy(a => a.ThemeId)
            .Select(g => new
            {
                Theme = g.Key,
                Total = g.Count(),
                Correct = g.Count(a => a.IsCorrect),
                Percentage = Math.Round((double) g.Count(a => a.IsCorrect) / g.Count() * 100)
            });

        Console.Clear();
        ConsoleUtil.TypeLine(_localizer["results.header"]);
        ConsoleUtil.TypeLine();

        var themes = _yamlLoader.LoadThemes("Data/themes.yaml")
            .ToDictionary(t => t.Id, t => t.Title);
        
        foreach (var stat in grouped)
        {
            var title = themes.TryGetValue(stat.Theme ?? "common", out var t)
                ? t
                : _localizer["theme.unknown"];
            Console.WriteLine($"{title}: {stat.Correct}/{stat.Total} ({stat.Percentage}%)");
        }

        ConsoleUtil.TypeLine();
        ConsoleUtil.TypeLine(_localizer["quiz.press_any_key"]);
        Console.ReadKey();
    }
}