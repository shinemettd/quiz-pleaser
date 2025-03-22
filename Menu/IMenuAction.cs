namespace QuizPleaser.Menu;

public interface IMenuAction
{
    string Name { get; }
    void Execute();
}