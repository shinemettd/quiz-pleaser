using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class ShowResultsAction(ILocalizer localizer) : IMenuAction
{
    private readonly ILocalizer _localizer;
    
    public string Name => _localizer["menu.results"];
    
    public void Execute()
    {
        
    }
}