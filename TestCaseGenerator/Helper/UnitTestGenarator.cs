using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TestCaseGenerator.Helper;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace TestCaseGenerator
{
    public static class UnitTestGenerator
    {
        public static void GenerateUnitTests(string filePath)
        {
            // Read the contents of the file
            var fileContents = File.ReadAllText(filePath);

            // Extract the methods and their logic
            var methodRegex = new Regex(@"public\s+async\s+Task<IActionResult>\s+(?<methodName>\w+)\((?<arguments>.*)");
            var methods = methodRegex.Matches(fileContents);
            var fileName = Path.GetFileName(filePath);

            // Read and get all the methods from MatchCollection.
            var classModel = GetAllMethods(fileName.Replace(".cs", ""), methods);

            // Path to generate the txt file.
            var unitTestsContentsPath = System.AppDomain.CurrentDomain.BaseDirectory
                .Replace("\\bin", "")
                .Replace("\\Debug", "") + "UnitTestFiles\\" + fileName.Replace(".cs", "Test.txt");

            // Generate the json object txt file from basic class model. which can be utilized for further operations.
            GenerateFileWithData(unitTestsContentsPath, classModel);

            // Read the text file and get the basic class model object.
            var testFileObject = GetTestClassModel(unitTestsContentsPath);

            // Path to generate Unit Test file.
            var unitTestsFilePath = System.AppDomain.CurrentDomain.BaseDirectory
                .Replace("\\bin", "")
                .Replace("\\Debug", "") + "UnitTestFiles\\" + fileName.Replace(".cs", "Test.cs");

            // To generate the unit test template
            GenerateUnitTestTemplate(unitTestsFilePath, testFileObject);
           
        }
        public static string RemoveBetween(string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.RightToLeft);
            return regex.Replace(sourceString, startTag + endTag);
        }

        private static TestClassModel GetAllMethods(string className, MatchCollection methods)
        {
            var classModel = new TestClassModel() { ClassName = className, Methods = new List<MethodModel>() };

            foreach (Match method in methods)
            {
                var returnType = method.Groups["returnType"].Value;
                var methodName = method.Groups["methodName"].Value;
                var arguments = method.Groups["arguments"].Value;
                MethodModel methodModel = new MethodModel();
                methodModel.ReturnType = returnType;
                methodModel.MethodName = methodName;
                methodModel.Arguments = new List<ArgumentModel>();
                foreach (var arg in arguments.Split(','))
                {
                    var argWithDataType = RemoveBetween(arg, "[", "]").Replace("[]", "").Trim().Split(' ');
                    if (argWithDataType.Length > 1)
                    {
                        ArgumentModel argumentModel = new ArgumentModel() { ArgumentType = argWithDataType[0], ArgumentName = argWithDataType[1].TrimEnd(')') };
                        methodModel.Arguments.Add(argumentModel);
                    }
                }

                classModel.Methods.Add(methodModel);
            }
            return classModel;
        }
        private static bool GenerateFileWithData(string filePath, TestClassModel classModel)
        {
            bool isGenerated = false;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string jsonString = JsonConvert.SerializeObject(classModel);
                writer.WriteLine(jsonString);
                writer.WriteLine("\n");
                isGenerated = true;
            }
            return isGenerated;

        }

        private static bool GenerateUnitTestTemplate(string filePath, TestClassModel classModel)
        {
            bool isGenerated = false;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("using Xunit;");
                writer.WriteLine("namespace UnitTestGenerator");
                writer.WriteLine("{");
                writer.WriteLine("    public class TestMethods");
                writer.WriteLine("    {");
                // For each extracted method, write a corresponding test method
                foreach (var method in classModel.Methods)
                {

                    string arguments = method.Arguments.Any() ? string.Join(", ", method.Arguments.Select(x => x.ArgumentName)) : string.Empty;
                    // Write the test method using the extracted information
                    writer.WriteLine("        [Fact]");
                    writer.WriteLine("        public void " + method.MethodName + "Test()");
                    writer.WriteLine("        {");
                    writer.WriteLine("            // Arrange");

                    // TODO: Add code for arranging the test inputs
                    writer.WriteLine("            // Act");
                    writer.WriteLine("            var result = " + method.MethodName + "(" + arguments + ");");

                    writer.WriteLine("            // Assert");
                    // TODO: Add code for asserting the expected results
                    writer.WriteLine("        }");
                    writer.WriteLine("");
                }
                writer.WriteLine("    }");
                writer.WriteLine("}");
                writer.WriteLine("\n");
                isGenerated = true;
            }
            return isGenerated;

        }

        private static TestClassModel GetTestClassModel(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            var testClassModel = JsonConvert.DeserializeObject<TestClassModel>(fileContents);
            return testClassModel;

        }
    }
}
