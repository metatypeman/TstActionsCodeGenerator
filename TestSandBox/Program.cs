using NLog;
using TestSandBox.Functors;

namespace TestSandBox
{
    internal class Program
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _logger.Info("Hello, World!");

            Case1();
        }

        private static void Case1()
        {
            var codeChunksContext = new CodeChunksContext("8F7DC54F-DA8E-434C-A6E3-279882011280");

            codeChunksContext.CreateCodeChunk("A5B7498A-8511-4160-89EE-DA2C76232173", (currentCodeChunk) =>
            {
                //"6F3683B4-2836-4D42-B8F5-798813B06D6D"
            });
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.Info($"e.ExceptionObject = {e.ExceptionObject}");
        }
    }
}
