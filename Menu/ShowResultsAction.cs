using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class ShowResultsAction : IMenuAction
{
    private readonly ILocalizer _localizer;

    public ShowResultsAction(ILocalizer localizer)
    {
        _localizer = localizer;
    }
    
    public string Name => _localizer["menu.results"];
    
    public void Execute()
    {
        
    }
}