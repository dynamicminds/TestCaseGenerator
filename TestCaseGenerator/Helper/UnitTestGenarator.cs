using System.IO;
using System.Text.RegularExpressions;

namespace TestCaseGenerator
{
    public static class UnitTestGenerator
    {
        public static void GenerateUnitTests(string filePath)
        {
            // Read the contents of the file
            var fileContents = File.ReadAllText(filePath);

            // Extract the methods and their logic
            var methodRegex =  new Regex(@"public\s+async\s+Task<IActionResult>\s+(?<methodName>\w+)\((?<arguments>.*)");
            var methods = methodRegex.Matches(fileContents);
            // var unitTestsFilePath = "D:\\Development\\LSAC\\Backend\\UnitTests\\GeneratedUnitTests.cs";
            var fileName = Path.GetFileName(filePath);
            var unitTestsFilePath = System.AppDomain.CurrentDomain.BaseDirectory
                .Replace("\\bin","")
                .Replace("\\Debug", "") + "UnitTestFiles\\"+ fileName.Replace(".cs","Test.cs");

            using (StreamWriter writer = new StreamWriter(unitTestsFilePath))
            {
                writer.WriteLine("using Xunit;");
                writer.WriteLine("namespace UnitTestGenerator");
                writer.WriteLine("{");
                writer.WriteLine("    public class TestMethods");
                writer.WriteLine("    {");
                // For each extracted method, write a corresponding test method
                foreach (Match method in methods)
                {
                var returnType = method.Groups["returnType"].Value;
                var methodName = method.Groups["methodName"].Value;
                var arguments = method.Groups["arguments"].Value;

                // Write the test method using the extracted information
                    writer.WriteLine("        [Fact]");
                    writer.WriteLine("        public void " + methodName + "Test()");
                    writer.WriteLine("        {");
                    writer.WriteLine("            // Arrange");

                    // TODO: Add code for arranging the test inputs
                    writer.WriteLine("            // Act");
                    writer.WriteLine("            " + returnType + " result = " + methodName + "(" + arguments +"");

                    writer.WriteLine("            // Assert");
                    // TODO: Add code for asserting the expected results
                    writer.WriteLine("        }");
                    writer.WriteLine("    }");
                }
                writer.WriteLine("}");
                writer.WriteLine("\n");
            }
        }
    }
}
