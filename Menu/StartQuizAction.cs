using QuizPleaser.Models;
using QuizPleaser.Services;
using QuizPleaser.Utils;

namespace QuizPleaser.Menu;

public class StartQuizAction : IMenuAction
{
    private readonly ILocalizer _localizer;
    private readonly IResultService _resultService;
    private readonly IQuizService _quiz;

    public StartQuizAction(ILocalizer localizer, IQuizService quiz, IResultService resultService)
    {
        _localizer = localizer;
        _quiz = quiz;
        _resultService = resultService;
    }
    
    public string Name => _localizer["menu.start"];
    
    public void Execute()
    {
        var questions = _quiz.GetAvailableQuestions();

        if (!questions.Any())
        {
            ConsoleUtil.TypeLine(_localizer["quiz.no_questions"]);
            Console.ReadKey();
            return;
        }

        ConsoleUtil.Type(_localizer["quiz.question_count_prompt"] + $"({questions.Count})");
        ConsoleUtil.TypeLine();
        var input = Console.ReadLine();
        int.TryParse(input, out var count);

        if (count <= 0 || count > questions.Count)
            count = Math.Min(5, questions.Count);

        var selectedQuestions = questions
            .OrderBy(_ => Guid.NewGuid())
            .Take(count)
            .ToList();
        
        ListUtil.Shuffle(selectedQuestions);

        int correctCount = 0;
        
        foreach (var question in selectedQuestions)
        {
            Console.Clear();
            ConsoleUtil.TypeLine(question.Text);
            ConsoleUtil.TypeLine();

            for (int i = 0; i < question.Answers.Count; i++)
            {
                ConsoleUtil.TypeLine($"{i + 1}. {question.Answers[i]}");
            }

            ConsoleUtil.Type(_localizer["quiz.answer_prompt"]);
            var answerInput = Console.ReadLine();
            int.TryParse(answerInput, out var answerIndex);
            answerIndex--;

            var hash = question.GetHash();

            _resultService.SaveAnswer(new UserAnswer
            {
                QuestionHash = hash,
                ThemeId = question.ThemeId,
                IsCorrect = answerIndex == question.CorrectAnswerIndex
            });
            
            Console.Clear();
            
            //todo: mode with display if answer status

            if (_quiz.IsAnswerCorrect(question, answerIndex))
            {
                // ConsoleUtil.TypeLine(_localizer["quiz.correct"]);
                correctCount++;
            }
            else
            {
                // ConsoleUtil.TypeLine(_localizer["quiz.wrong"]);
                // ConsoleUtil.TypeLine($"{_localizer["quiz.correct_answer"]}: {question.Answers[question.CorrectAnswerIndex]}");
            }
            //
            // ConsoleUtil.TypeLine();
            // ConsoleUtil.TypeLine(_localizer["quiz.press_any_key"]);
            // Console.ReadKey();
        }
        Console.Clear();
        ConsoleUtil.TypeLine($"{_localizer["quiz.result_summary"]} {correctCount} / {selectedQuestions.Count}");
        Console.WriteLine();
        ConsoleUtil.TypeLine(_localizer["quiz.press_any_key"]);
        Console.ReadKey();
    }

}