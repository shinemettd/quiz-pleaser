using QuizPleaser.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace QuizPleaser.Services;

public class YamlLoader : IYamlLoader
{
    private readonly IDeserializer _deserializer;
    
    private readonly ILocalizer _localizer;
    
    public YamlLoader(ILocalizer localizer)
    {
        _localizer = localizer;
        
        _deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();
    }
    
    public List<Theme> LoadThemes(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"{_localizer["error.file_not_found"]}: {path}");

        var text = File.ReadAllText(path);
        var result = _deserializer.Deserialize<ThemeSet>(text);
        return result?.Themes ?? [];
    }

    public List<Question> LoadQuestions(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"{_localizer["error.file_not_found"]}: {path}");

        var text = File.ReadAllText(path);
        var result = _deserializer.Deserialize<QuestionSet>(text);
        return result?.Questions ?? [];
    }
}