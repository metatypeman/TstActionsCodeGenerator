using NLog;
using TestSandBox.Functors;
using TestSandBox.SerializableObjects;
using TestSandBox.Serialization;

namespace TestSandBox
{
    internal class Program
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _logger.Info("Hello, World!");

            TstPlainObjectsRegistry();
            //Case2();
            //Case1();
        }

        private static string ExtractNamespaceNameFromUsing(string usingContent)
        {
            _logger.Info($"usingContent = '{usingContent}'");

            if (string.IsNullOrWhiteSpace(usingContent))
            {
                return string.Empty;
            }

            if (usingContent.Contains("=") ||
                usingContent.Contains(" static "))
            {
                return string.Empty;
            }

            if(!usingContent.StartsWith("using "))
            {
                return string.Empty;
            }

            return usingContent.Trim().Substring(6).Replace(";", string.Empty).Trim();
        }

        private static void TstPlainObjectsRegistry()
        {
            var usingStr = ExtractNamespaceNameFromUsing("using System.Text;");

            _logger.Info($"usingStr = '{usingStr}'");

            usingStr = ExtractNamespaceNameFromUsing("using Project = PC.MyCompany.Project;");

            _logger.Info($"usingStr = '{usingStr}'");

            usingStr = ExtractNamespaceNameFromUsing("global using static System.Math;");

            _logger.Info($"usingStr = '{usingStr}'");

            usingStr = ExtractNamespaceNameFromUsing("using static System.Console;");

            _logger.Info($"usingStr = '{usingStr}'");

            var usingsList = new List<string>()
            {
                "System",
                "NLog",
                "TestSandBox.SerializableObjects",
                "TestSandBox.Serialization",
                "TestSandBox",                
                "TestSandBox.Functors",
            };

            var plainObjectsRegistry = new PlainObjectsRegistry();

            plainObjectsRegistry.Add("TestSandBox.Functors.BaseClass", 0, "BaseClassPo");
            plainObjectsRegistry.Add("TestSandBox.Functors.BaseClass", 1, "BaseClassPo_T");
            plainObjectsRegistry.Add("TestSandBox.Functors.BaseClass", 2, "BaseClassPo_T_U");

            plainObjectsRegistry.Add("TestSandBox.SomeClass", 0, "SomeClassPo");

            var plainObject1 = plainObjectsRegistry.Get("TestSandBox.Functors.BaseClass", 1);

            _logger.Info($"plainObject1 = '{plainObject1}'");

            var plainObject2 = plainObjectsRegistry.Get(usingsList, "TestSandBox.Functors.BaseClass", 2);

            _logger.Info($"plainObject2 = '{plainObject2}'");

            var plainObject3 = plainObjectsRegistry.Get(usingsList, "BaseClass", 0);

            _logger.Info($"plainObject3 = '{plainObject3}'");
        }

        private static void Case2()
        {
            BaseSerializableObject obj = new SerializableObject();

            var serializable = obj as ISerializable;

            _logger.Info($"serializable.GetPlainObjectType().FullName = {serializable.GetPlainObjectType().FullName}");

            var plainObject = new SerializableObjectPo();

            serializable.OnWritePlainObject(plainObject, null);
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
