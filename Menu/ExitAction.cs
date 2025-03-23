using QuizPleaser.Services;
using QuizPleaser.Utils;

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
        ConsoleUtil.TypeLine(_localizer["menu.bye_message"], 50);
        Environment.Exit(0);
    }
}