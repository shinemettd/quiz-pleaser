using System.Text.Json;

namespace QuizPleaser.Services;

public class JsonLocalizer : ILocalizer
{
    private readonly Dictionary<string, string> _strings;

    public JsonLocalizer(string langCode)
    {
        var path = Path.Combine("Localization", $"{langCode}.json");
        
        if (!File.Exists(path)) 
            throw new FileNotFoundException($"Localization file not found: {path}");
        
        var json = File.ReadAllText(path);
        _strings = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
    }
    
    public string this[string key] => _strings.TryGetValue(key, out var value) ? value : $"!{key}!";
}