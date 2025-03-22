namespace QuizPleaser.Services;

public interface ILocalizer
{
    string this[string key] { get; }
}