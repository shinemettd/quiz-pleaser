using QuizPleaser.Menu;
using QuizPleaser.Services;

namespace QuizPleaser;

public class App
{
    private readonly ILocalizer _localizer;
    private readonly IEnumerable<IMenuAction> _actions;

    public App(ILocalizer localizer, IEnumerable<IMenuAction> actions)
    {
        _localizer = localizer;
        _actions = actions;
    }
    
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(_localizer["menu.title"]);

            var actionList = _actions.ToList();

            for (int i = 0; i < actionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actionList[i].Name}");
            }

            Console.Write(_localizer["menu.choice"]);
            var input = Console.ReadLine();

            if (int.TryParse(input, out int choice) &&
                choice >= 1 && choice <= actionList.Count)
            {
                Console.Clear();
                actionList[choice - 1].Execute();
            }
            else
            {
                Console.WriteLine(_localizer["error.invalid_input"]);
                Thread.Sleep(1000);
            }
        }
    }
}