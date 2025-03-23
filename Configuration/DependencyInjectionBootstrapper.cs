using Microsoft.Extensions.DependencyInjection;
using QuizPleaser.Menu;
using QuizPleaser.Services;

namespace QuizPleaser.Configuration;

public class DependencyInjectionBootstrapper
{
    public static App LoadApp()
    {
        var services = new ServiceCollection();

        var languageManager = new LanguageManager();
        var selectedLang = languageManager.ChooseLanguage();

        services.AddSingleton<ILocalizer>(_ => new JsonLocalizer(selectedLang));
        services.AddSingleton<IYamlLoader, YamlLoader>();
        services.AddSingleton<LanguageManager>();

        services.AddSingleton<IMenuAction, StartQuizAction>();
        services.AddSingleton<IMenuAction, ShowResultsAction>();
        // services.AddSingleton<IMenuAction, ImportDataAction>();
        services.AddSingleton<IMenuAction, ExitAction>();
        
        services.AddSingleton<IQuizService, QuizService>();
        services.AddSingleton<IResultService, ResultService>();

        services.AddSingleton<App>();

        var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<App>();
    }
}