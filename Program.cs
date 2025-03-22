using QuizPleaser.Configuration;

namespace QuizPleaser;

class Program
{

    public static void Main(string[] args)
    {
        var app = DependencyInjectionBootstrapper.LoadApp();
        app.Run();
    }
 
}

