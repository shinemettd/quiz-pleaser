using System.Text.Json;

namespace QuizPleaser.Services;

public class LanguageManager
{
    private const string LocalizationFolder = "Localization";
    private const string DefaultLanguage = "en";

    public string ChooseLanguage()
    {
        var existingConfig = ConfigManager.Load();

        if (!string.IsNullOrWhiteSpace(existingConfig.Language))
        {
            return existingConfig.Language;
        }
        
        string selectedLanguage = ManualLanguageChoose();
        
        existingConfig.Language = selectedLanguage;
        ConfigManager.Save(existingConfig);
        
        return selectedLanguage;
    }

    private static string ManualLanguageChoose()
    {
        var languageFiles = Directory.GetFiles(LocalizationFolder, "*.json");

        if (languageFiles.Length == 0)
        { 
            NoLocalizationExit();
        }

        var availableLanguages = languageFiles
            .Select(path => (
                Code: Path.GetFileNameWithoutExtension(path),
                Name: GetLanguageDisplayName(path)
            ))
            .Distinct()
            .Order()
            .ToList();
    
        int langIndex = GetLanguageIndexFromUser(availableLanguages);

        return langIndex == -1 ? DefaultLanguage : availableLanguages[langIndex].Code;
    }
    
    private static string GetLanguageDisplayName(string filePath)
    {
        var json = File.ReadAllText(filePath);

        using var doc = JsonDocument.Parse(json);
        if (doc.RootElement.TryGetProperty("lang.name", out var name))
            return name.GetString() ?? Path.GetFileNameWithoutExtension(filePath);

        return Path.GetFileNameWithoutExtension(filePath);
    }

    private static int GetLanguageIndexFromUser(List<(string Code, string Name)> languages)
    {
        Console.WriteLine("Choose language:");

        for (int i = 0; i < languages.Count; i++)
            Console.WriteLine($"{i + 1}. {languages[i].Name}");

        Console.Write("Choice: ");
        var input = Console.ReadLine();

        return int.TryParse(input, out var index) ? index - 1 : -1;
    }

    private static void NoLocalizationExit()
    {
        Console.WriteLine("No localization files found in 'Localization/'");
        Console.WriteLine("Make sure at least 'en.json' exists");
        Environment.Exit(1);
    }
}