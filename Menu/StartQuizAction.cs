using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class StartQuizAction(ILocalizer localizer) : IMenuAction
{
    private readonly ILocalizer _localizer;
    
    public string Name => _localizer["menu.start"];
    
    public void Execute()
    {
        
    }
}