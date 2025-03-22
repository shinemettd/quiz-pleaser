using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class ExitAction(ILocalizer localizer) : IMenuAction
{
    private readonly ILocalizer _localizer;
    
    public string Name => _localizer["menu.exit"];
    
    public void Execute()
    {
        Environment.Exit(0);
    }
}