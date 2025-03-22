using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class StartQuizAction : IMenuAction
{
    private readonly ILocalizer _localizer;

    public StartQuizAction(ILocalizer localizer)
    {
        _localizer = localizer;
    }
    
    public string Name => _localizer["menu.start"];
    
    public void Execute()
    {
        
    }
}