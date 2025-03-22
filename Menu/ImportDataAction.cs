using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class ImportDataAction(ILocalizer localizer) : IMenuAction
{
    private readonly ILocalizer _localizer;
    
    public string Name => _localizer["menu.import"];
    
    public void Execute()
    {
        
    }
}