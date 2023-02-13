using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TestCaseGenerator.Helper;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Text;
using TestCaseGenerator.Constants;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace TestCaseGenerator
{
    public class TestGenerator
    {
        public FileParamters fileParameters;

        public void GenerateDummyFileParameters()
        {
            fileParameters = new FileParamters()
            {
                InputFileName = "EmployeeController.cs",
                InputPath = "d:\\xyz\\",
                methodParameters = new List<MethodParameters>
                 {
                     new MethodParameters
                     {
                         Name = "GetEmployee",
                         Signature = new List<DataType>
                         { new DataType
                            {
                             Name = "employeeId",
                             Type = "string"
                            }
                         }
                     }
                 },
                OutputFileName = "EmployeeControllerTest.cs",
                OutputPath = "d:\\xyz\\",
                ReferencedClassNames = new List<string>
                 {
                    "IEmployeeService"
                 }
            };
        }

        public static void ReadInputFile()
        {
            // Read file and at update fileParameters
        }

        public void ReadClassConstructor()
        {
            // Read class constructor and extract class references and store in ReferencedClassNames
        }

        //public string GenerateUnitTestConstructor()
        //{
        //    // Generate constructor and initialised Controller class and ReferencedClassName
        //}

        //public string GenerateUnitTestMethodName()
        //{
        //    // Read FileParameters methodName + "_Returns" + ExceptionName
        //}

        //public string GenerateUnitTestArrangeValues()
        //{

        //}

        //public string GenerateUnitTestAssertValues()
        //{

        //}

        //public string GenerateUnitTestActValues()
        //{
        //    // Generate 
        //}

        public static void WriteInputFile()
        {
            // Write file to output path+filename
        }
    }


    public static class UnitTestGenerator
    {
        public static void GenerateUnitTests(string filePath, string destinationPath, string testFileName)
        {
            TryIt(filePath);

            // Read the contents of the file
            var fileContents = File.ReadAllText(filePath);

            // Extract the methods and their logic
            var methodRegex = new Regex(@"public\s+async\s+Task<IActionResult>\s+(?<methodName>\w+)\((?<arguments>.*)");
            var methods = methodRegex.Matches(fileContents);
            var fileName = Path.GetFileName(filePath);

            // Read and get all the methods from MatchCollection.
            var classModel = GetAllMethods(fileName.Replace(".cs", ""), methods);

            // Path to generate the txt file.
            //var unitTestsContentsPath = System.AppDomain.CurrentDomain.BaseDirectory
            //    .Replace("\\bin", "")
            //    .Replace("\\Debug", "") + "UnitTestFiles\\" + fileName.Replace(".cs", "Test.txt");
            var unitTestsContentsPath = destinationPath + "\\" + testFileName + ".txt";
            // Generate the json object txt file from basic class model. which can be utilized for further operations.
            GenerateFileWithData(unitTestsContentsPath, classModel);

            // Read the text file and get the basic class model object.
            var testFileObject = GetTestClassModel(unitTestsContentsPath);

            // Path to generate Unit Test file.
            //var unitTestsFilePath = System.AppDomain.CurrentDomain.BaseDirectory
            //    .Replace("\\bin", "")
            //    .Replace("\\Debug", "") + "UnitTestFiles\\" + fileName.Replace(".cs", "Test.cs");
            var unitTestsFilePath = destinationPath + "\\" + testFileName + ".cs";
            // To generate the unit test template
            GenerateUnitTestTemplate(unitTestsFilePath, testFileObject);



        }
        private static string TryIt(string csFilePath)
        {
            var output = new Dictionary<string, MatchCollection>();

            var csFileContent = File.ReadAllText(csFilePath);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(csFileContent);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var nds = (NamespaceDeclarationSyntax)root.Members[0];
            var cds = (ClassDeclarationSyntax)nds.Members[0];
            string catchPattern = @"catch\s\(\s*(.*?)\s+([a-zA-Z_][a-zA-Z0-9_]*)\s*\)\s*\{(.*?)\}";

            foreach (var ds in cds.Members)
            {
                //Only take methods into consideration
                if (ds is MethodDeclarationSyntax)
                {
                    var mds = (MethodDeclarationSyntax)ds;

                    //Method name
                    var methodName = ((SyntaxToken)mds.Identifier).ValueText;

                    //Method body (including curly braces)
                    var methodBody = mds.Body.ToString();
                    MatchCollection catchMatches = Regex.Matches(methodBody, catchPattern, RegexOptions.Singleline);

                    output.Add(methodName, catchMatches);
                }
            }

            return "";
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
                writer.WriteLine(GenerateUnitTestMethod(classModel.Methods));
                
                writer.WriteLine("    }");
                writer.WriteLine("}");
                writer.WriteLine("\n");
                isGenerated = true;
            }
            return isGenerated;

        }


        private static string GenerateUnitTestMethod(List<MethodModel> methodModels)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var method in methodModels)
            {
                string responseName = "response";

                sb.AppendLine("        [Fact]");
                sb.AppendLine("        public void " + method.MethodName + "Test()");
                sb.AppendLine("        {");
                // Area to Arrange the test variables.
                if (method.Arguments != null && method.Arguments.Any())
                {
                    sb.AppendLine(GetArrangeContents(method.Arguments, 10));
                }
                // Area to make the Act contents.
                sb.AppendLine(GetActContents(responseName, method.MethodName, method.Arguments, 10));
                // Area to set the Asserts based on conditions.
                sb.AppendLine(GetAssertContents(responseName, 10));
                sb.AppendLine("        }\n");
            }
            return sb.ToString();
        }

        private static string GetArrangeContents(List<ArgumentModel> arguments, int noOfRightPadding = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}// Arrange\n", "".PadRight(noOfRightPadding));
            foreach (var argument in arguments)
            {
                //sb.AppendFormat("{0}{1} {2} = null;{3}", startingSpaces, argument.ArgumentType, argument.ArgumentName, Environment.NewLine);
                sb.AppendFormat("{0}{1} {2};\n", "".PadRight(noOfRightPadding), argument.ArgumentType, argument.ArgumentName);
            }

            return sb.ToString();
        }

        private static string GetAssertContents(string responseName, int noOfRightPadding = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}// Assert\n", "".PadRight(noOfRightPadding));

            // need to handle this asserts based on arguments and test case types. temporarly created this asserts for testing.
            sb.AppendFormat("{0}Assert.NotNull({1});\n", "".PadRight(noOfRightPadding), responseName);
            sb.AppendFormat("{0}Assert.Equal(StatusCodes.Status400BadRequest, {1}.StatusCode);\n", "".PadRight(noOfRightPadding), responseName);
            sb.AppendFormat("{0}Assert.NotNull({1}.Value);", "".PadRight(noOfRightPadding), responseName);
            return sb.ToString();
        }

        private static string GetActContents(string responseName, string methodName, List<ArgumentModel> argumentList, int noOfRightPadding = 0)
        {
            string arguments = argumentList.Any() ? string.Join(", ", argumentList.Select(x => x.ArgumentName)) : string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}// Act\n", "".PadRight(noOfRightPadding));

            sb.AppendFormat("{0}var {1} = {2}({3});\n", "".PadRight(noOfRightPadding), responseName, methodName, arguments);
            return sb.ToString();
        }

        private static TestClassModel GetTestClassModel(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            var testClassModel = JsonConvert.DeserializeObject<TestClassModel>(fileContents);
            return testClassModel;

        }
    }
}
