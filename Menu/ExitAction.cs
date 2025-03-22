using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class ExitAction : IMenuAction
{
    private readonly ILocalizer _localizer;

    public ExitAction(ILocalizer localizer)
    {
        _localizer = localizer;
    }

    public string Name => _localizer["menu.exit"];
    
    public void Execute()
    {
        Environment.Exit(0);
    }
}