using QuizPleaser.Services;

namespace QuizPleaser.Menu;

public class ImportDataAction : IMenuAction
{
    private readonly ILocalizer _localizer;

    public ImportDataAction(ILocalizer localizer)
    {
        _localizer = localizer;
    }

    public string Name => _localizer["menu.import"];
    
    public void Execute()
    {
        
    }
}