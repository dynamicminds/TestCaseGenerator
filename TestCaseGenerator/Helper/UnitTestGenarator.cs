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
using System.Security.Cryptography;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace TestCaseGenerator
{
    public class TestGenerator
    {
        public FileParameters fileParameters;

        public FileParameters GenerateDummyFileParameters()
        {
            fileParameters = new FileParameters()
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
                         },
                         Exceptions = new List<DataType>
                         {
                             new DataType
                             {
                                 Name = "name",
                                 Type = "ArgumentException"
                             },
                             new DataType
                             {
                                 Name = "name",
                                 Type = "ObjectNotFoundException"
                             },
                             new DataType
                             {
                                 Name = "name",
                                 Type = "Exception"
                             }
                         },
                         ReturnValue = new DataType
                        {
                            Name = "name",
                            Type = "OkResult"
                        }
                     }
                 },
                OutputFileName = "EmployeeControllerTest.cs",
                OutputPath = "d:\\xyz\\",
                ReferencedClassNames = new List<string>
                 {
                    "IEmployeeService"
                 },
                ServiceClassName = "EmployeeService"
            };

            return fileParameters;
        }

        public static void ReadInputFile()
        {
            // Read file and at update fileParameters
        }

        //public void ReadClassConstructor()
        //{
        //    // Read class constructor and extract class references and store in ReferencedClassNames
        //}

        //public string GenerateUnitTestConstructor()
        //{
        //    // Generate constructor and initialised Controller class and ReferencedClassName
        //}

        //public string GenerateUnitTestMethodName()
        //{
        //    // Read FileParameters methodName + "_Returns" + ExceptionName
        //}

        public string GenerateUnitTestArrangeValues(MethodParameters methodParameter, string returnName, string exceptionName, string serviceFile)
        {
            string variableName = "";
            int ctr = methodParameter.Signature.Count();
            foreach (var sign in methodParameter.Signature)
            {
                if (ctr == 1)
                {
                    variableName = sign.Name;
                }
                else
                {
                    variableName = variableName + ", " + sign.Name;

                }
            }

            StringBuilder code = new StringBuilder();
            code.AppendLine("\t\t[Fact]");
            code.AppendLine("\t\tpublic async void " + methodParameter.Name + "_Returns" + exceptionName + "()");
            code.AppendLine("\t\t{");
            code.AppendLine("\t\t\t// Arrange");
            foreach(var sign in methodParameter.Signature)
            {
                if (exceptionName == "ArgumentException")
                {
                    code.AppendLine("\t\t\t" + sign.Type + " " + sign.Name + " " +"= null;");
                }
                else
                {
                    if (sign.Type == "string")
                    {
                        code.AppendLine("\t\t\t" + sign.Type + " " + sign.Name + " " + "= " + "\"" + sign.Name.ToLower() + "\";");
                    }
                    else
                    {
                        code.AppendLine("\t\t\t" + sign.Type + " " + sign.Name + " " + "= " + "new" + sign.Type + "();");
                    }
                }
            }

            if( exceptionName != "ArgumentException")
            {
                code.AppendLine("\t\t\tmock" + serviceFile + ".Setup(service => service." + methodParameter.Name + "(" + variableName + ").Throws<" + exceptionName +">();");
            }

            return code.ToString();
        }

        public string GenerateUnitTestAssertValues(MethodParameters methodParamter, string returnName, string exceptionName)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("\t\t\t// Assert");
            switch (exceptionName)
            {
                case "ArgumentException":
                    code.AppendLine("\t\t\tAssert.Equal(StatusCodes.Status400BadRequest, responseObject.StatusCode);");
                    break;
                case "ObjectNotFoundException":
                    code.AppendLine("\t\t\tAssert.Equal(StatusCodes.Status404NotFound, responseObject.StatusCode);");
                    break;
                case "Exception":
                    code.AppendLine("\t\t\tAssert.Equal(StatusCodes.Status500InternalServerError, (responseObject as StatusCodeResult)?.StatusCode);");
                    break;
                default:
                    code.AppendLine("\t\t\tAssert.IsType<OkObjectResult>(responseObject);");
                    break;
            }
            code.AppendLine("\t\t}");
            return code.ToString();
        }

        public string GenerateUnitTestActValues(MethodParameters methodParameter, string returnName, string exceptionName)
        {
            string variableName = "";
            int ctr = methodParameter.Signature.Count();
            foreach (var sign in methodParameter.Signature)
            {
                if (ctr == 1)
                {
                    variableName = sign.Name;
                }
                else
                {
                    variableName = variableName + ", " + sign.Name;

                }
            }

            StringBuilder code = new StringBuilder();
            code.AppendLine("\t\t\t// Act");
            switch (exceptionName)
            {
                case "ArgumentException":
                    code.AppendLine("\t\t\tvar responseObject = await this.controller." + methodParameter.Name + "(" + variableName + ") as ObjectResult;");
                    break;
                case "ObjectNotFoundException":
                    code.AppendLine("\t\t\tvar responseObject = await this.controller." + methodParameter.Name + "(" + variableName + ") as ObjectResult;");
                    break;
                case "Exception":
                    code.AppendLine("\t\t\tvar responseObject = await this.controller." + methodParameter.Name + "(" + variableName + ");");
                    break;
                default:
                    code.AppendLine("\t\t\tvar responseObject = await this.controller." + methodParameter.Name + "(" + variableName + ");");
                    break;
            }
            return code.ToString();
        }

        public static void WriteInputFile()
        {
            // Write file to output path+filename
        }
    }


    public static class UnitTestGenerator
    {
        public static void GenerateUnitTests(string filePath, string destinationPath, string testFileName)
        {
            var fileParameters = ParseClassFile(filePath);

            fileParameters.InputPath = filePath;
            fileParameters.OutputPath = destinationPath;
            fileParameters.OutputFileName = testFileName;

            // Path to generate the txt file.
            var unitTestsContentsPath = destinationPath + "\\" + testFileName + ".txt";
            // Generate the json object txt file from basic class model. which can be utilized for further operations.
            GenerateFileWithData(unitTestsContentsPath, fileParameters);

            // Read the text file and get the basic class model object.
            var testFileObject = GetTestClassModel(unitTestsContentsPath);

            // Path to generate Unit Test file.
            var unitTestsFilePath = destinationPath + "\\" + testFileName + ".cs";
            // To generate the unit test template
            GenerateUnitTestTemplate(unitTestsFilePath, testFileObject);



        }
        private static FileParamters ParseClassFile(string csFilePath)
        {
            FileParamters fileParameters = new FileParamters() { ReferencedClassNames = new List<DataType>(), methodParameters = new List<MethodParameters>() };

            var csFileContent = File.ReadAllText(csFilePath);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(csFileContent);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var nds = (NamespaceDeclarationSyntax)root.Members[0];
            var cds = (ClassDeclarationSyntax)nds.Members[0];
            string catchPattern = @"catch\s\(\s*(.*?)\s+([a-zA-Z_][a-zA-Z0-9_]*)\s*\)\s*\{(.*?)\}";

            //Class Name
            fileParameters.ClassName = cds.Identifier.ValueText;

            foreach (var ds in cds.Members)
            {
                MethodParameters methodParameter = new MethodParameters() { Signature = new List<DataType>(), Exceptions = new List<DataType>() };
                //Only take methods into consideration
                if (ds is MethodDeclarationSyntax)
                {
                    var mds = (MethodDeclarationSyntax)ds;

                    //Method Name
                    methodParameter.Name = ((SyntaxToken)mds.Identifier).ValueText;

                    //Method Return Type
                    string returnType = ((GenericNameSyntax)mds.ReturnType).TypeArgumentList.Arguments.ToFullString();
                    methodParameter.ReturnValue = new DataType() { Name = returnType };

                    //Method Signatures
                    string signetures = mds.ParameterList.Parameters.ToFullString();
                    foreach (var signature in signetures?.Split(','))
                    {
                        var argWithDataType = RemoveBetween(signature, "[", "]").Replace("[]", "").Trim().Split(' ');
                        if (argWithDataType.Length > 1)
                        {
                            DataType signatureDataType = new DataType() { Type = argWithDataType[0], Name = argWithDataType[1].TrimEnd(')') };
                            methodParameter.Signature.Add(signatureDataType);
                        }
                    }

                    //Method body (including curly braces)
                    var methodBody = mds.Body.ToString();

                    //Method Catch/Exception Names.
                    MatchCollection catchMatches = Regex.Matches(methodBody, catchPattern, RegexOptions.Singleline);
                    foreach (Match catchBlock in catchMatches)
                    {
                        //TODO : need to refactor this split logic.
                        string[] separator = { "catch (" };
                        var exceptionName = catchBlock.Value.Split(separator, System.StringSplitOptions.RemoveEmptyEntries)[0].Split(' ')[0];
                        DataType exceptionDataType = new DataType() { Type = exceptionName, Name = exceptionName };
                        methodParameter.Exceptions.Add(exceptionDataType);
                    }
                    fileParameters.methodParameters.Add(methodParameter);
                }
                if (ds is ConstructorDeclarationSyntax)
                {

                    var constructorDeclaration = (ConstructorDeclarationSyntax)ds;
                    string signetures = constructorDeclaration.ParameterList.Parameters.ToFullString();
                    string[] separator = { ",\r\n" };
                    foreach (var signature in signetures?.Split(separator, System.StringSplitOptions.RemoveEmptyEntries))
                    {
                        var constructorParameters = signature.Trim(' ').Split(' ');
                        DataType dataType = new DataType() { Name = constructorParameters[1], Type = constructorParameters[0] };
                        fileParameters.ReferencedClassNames.Add(dataType);
                    }
                }
                //TODO : USe the below documentation to get the catch blocks without regex.
                // https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.catchclausesyntax?view=roslyn-dotnet
                //TODO: we can do some RND to get the parameter/signature types directly.
                //var parameters = mds.ParameterList.Parameters;
                //foreach (var parameter in parameters)
                //{
                //    var parameterType = parameter.Type;
                //    var parameterName = ((SyntaxToken)parameter.Identifier).ValueText;
                //}

            }
            return fileParameters;
        }
        public static string RemoveBetween(string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.RightToLeft);
            return regex.Replace(sourceString, startTag + endTag);
        }

        private static bool GenerateFileWithData(string filePath, FileParamters dataModel)
        {
            bool isGenerated = false;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string jsonString = JsonConvert.SerializeObject(dataModel);
                writer.WriteLine(jsonString);
                writer.WriteLine("\n");
                isGenerated = true;
            }
            return isGenerated;

        }

        private static bool GenerateUnitTestTemplate(string filePath, FileParamters fileParamters)
        {
            bool isGenerated = false;
            string testClassName = fileParamters.ClassName + "Tests";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(GenerateUnitTestNameSpaces());
                writer.WriteLine("namespace UnitTestGenerator");
                writer.WriteLine("{");
                writer.WriteLine("   public class " + testClassName);
                writer.WriteLine("   {");
                writer.WriteLine(GenerateUnitTestVariables(fileParamters.ReferencedClassNames, fileParamters.ClassName, 7));
                writer.WriteLine(GenerateUnitTestConstructor(fileParamters.ReferencedClassNames, testClassName, 7));
                writer.WriteLine(GenerateUnitTestMethods(fileParamters.methodParameters));
                writer.WriteLine("   }");

                writer.WriteLine("}");
                writer.WriteLine("\n");
                isGenerated = true;
            }
            return isGenerated;

        }

        private static string GenerateUnitTestConstructor(List<DataType> constructorParameters, string testClassName, int noOfRightPadding = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}public {1}()\n", "".PadRight(noOfRightPadding), testClassName);
            sb.AppendFormat("{0}{{\n", "".PadRight(noOfRightPadding));
            sb.AppendFormat("  {0}this.{1} = new {2}(", "".PadRight(noOfRightPadding), testClassName.DoCamelCase(), testClassName);

            string mockObjectParameters = string.Empty;
            foreach (var parameter in constructorParameters)
            {
                mockObjectParameters += string.Format("this.mock{0}.Object, ", parameter.Name.DoCamelCase(false));
            }
            sb.AppendFormat("{0});\n", mockObjectParameters.Trim().TrimEnd(','));
            sb.AppendFormat("{0}}}\n", "".PadRight(noOfRightPadding));
            return sb.ToString();
        }
        private static string GenerateUnitTestVariables(List<DataType> constructorParameters, string className, int noOfRightPadding = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}private readonly {1} {2};\n", "".PadRight(noOfRightPadding), className, className.DoCamelCase());

            foreach (var parameter in constructorParameters)
            {
                // sb.AppendLine("private readonly Mock<IDocumentDbRepository<PlatformUser>> mockPlatformUserRepository = new Mock<IDocumentDbRepository<PlatformUser>>();");
                sb.AppendFormat("{0}private readonly Mock<{1}> mock{2} = new Mock<{1}>();\n", "".PadRight(noOfRightPadding), parameter.Type, parameter.Name.DoCamelCase(false));
            }
            return sb.ToString();
        }


        public static string GenerateUnitTestNameSpaces()
        {
            StringBuilder sb = new StringBuilder();
            //TODO: Include all the possible namespaces dynamically here.
            sb.AppendLine("using Xunit;");
            return sb.ToString();
        }
        public static string GenerateUnitTestMethodName(string methodName, string exceptionName)
        {
            string testMethodName = "";
            if (exceptionName != null)
            {
                testMethodName = string.Format("{0}_Returns{1}Test", methodName, exceptionName);
            }
            else
            {
                testMethodName = string.Format("{0}_OkObjectResultTest", methodName);
            }
            return testMethodName;
        }

        private static string GenerateUnitTestMethods(List<MethodParameters> methodParameters)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var method in methodParameters)
            {
                if (method.Exceptions.Any())
                {
                    foreach (var exception in method.Exceptions)
                    {
                        sb.AppendLine(GenerateUnitTestMethod(method, exception.Name));
                    }
                }

                sb.AppendLine(GenerateUnitTestMethod(method));
            }
            return sb.ToString();
        }

        private static string GenerateUnitTestMethod(MethodParameters method, string exceptionName = null)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("        [Fact]");
            sb.AppendLine("        public void " + GenerateUnitTestMethodName(method.Name, exceptionName) + "()");
            sb.AppendLine("        {");
            // Area to Arrange the test variables.
            if (method.Signature != null && method.Signature.Any())
            {
                sb.AppendLine(GenerateUnitTestArrangeValues(method.Signature, 10));
            }
            // Area to make the Act contents.
            sb.AppendLine(GetActContents(method.Name, method.Signature, 10));
            // Area to set the Asserts based on conditions.
            sb.AppendLine(GenerateUnitTestAssertValues(exceptionName, 10));
            sb.AppendLine("        }\n");

            return sb.ToString();
        }


        private static string GetActContents(string methodName, List<DataType> signatureList, int noOfRightPadding = 0)
        {
            string arguments = signatureList.Any() ? string.Join(", ", signatureList.Select(x => x.Name)) : string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}// Act\n", "".PadRight(noOfRightPadding));

            sb.AppendFormat("{0}var response = {1}({2});\n", "".PadRight(noOfRightPadding), methodName, arguments);
            return sb.ToString();
        }

        private static string GenerateUnitTestArrangeValues(List<DataType> arguments, int noOfRightPadding = 0)
        {
            var systemDataTypes = GetAllPrimitiveTypes();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}// Arrange\n", "".PadRight(noOfRightPadding));
            foreach (var argument in arguments)
            {
                object argumentDefaultValue = GetDefaultValue(systemDataTypes, argument.Type.ToLower());
                sb.AppendFormat("{0}{1} {2} = {3};\n", "".PadRight(noOfRightPadding), argument.Type, argument.Name, argumentDefaultValue.ToDirectString());
            }

            return sb.ToString();
        }


        private static string GenerateUnitTestAssertValues(string exceptionName,int noOfRightPadding = 0)
        {
           

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}// Assert\n", "".PadRight(noOfRightPadding));

            // need to handle this asserts based on arguments and test case types. temporarly created this asserts for testing.
            sb.AppendFormat("{0}Assert.NotNull(response);\n", "".PadRight(noOfRightPadding));
            sb.AppendFormat("{0}Assert.NotNull(response.Value);\n", "".PadRight(noOfRightPadding));
            if (!string.IsNullOrEmpty(exceptionName))
            {
                var allExceptionStatusCodes = GetAllExceptionCodes();
                object exceptionStatusCode = GetDefaultValue(allExceptionStatusCodes, exceptionName);
                sb.AppendFormat("{0}Assert.Equal(StatusCodes.{1}, (response as StatusCodeResult)?.StatusCode);\n", "".PadRight(noOfRightPadding), exceptionStatusCode);
                sb.AppendFormat("{0}Assert.IsType<{1}>(response);", "".PadRight(noOfRightPadding), exceptionName);

            }
            else
            {
                sb.AppendFormat("{0}Assert.IsType<OkObjectResult>(response);", "".PadRight(noOfRightPadding));
            }
            return sb.ToString();
        }

        private static FileParamters GetTestClassModel(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            var testClassModel = JsonConvert.DeserializeObject<FileParamters>(fileContents);
            return testClassModel;

        }

        public static object GetDefaultValue(this Type t)
        {
            if (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
                return Activator.CreateInstance(t);
            else
                return null;
        }
        public static object GetDefaultValue(IDictionary<string, Type> dictionary, string key)
        {
            return dictionary.TryGetValue(key, out var value) ? GetDefaultValue(value) : null;
        }
        public static object GetDefaultValue(IDictionary<string, string> dictionary, string key)
        {
            return dictionary.TryGetValue(key, out var value) ? value : null;
        }
        static string ToDirectString(this object Value)
        {

            return Value == null ? "null" : Value.ToString();

        }

        public static string DoCamelCase(this string s, bool isCamelCase = true)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            if (s.Length == 1)
                return s.ToUpper();
            return (isCamelCase ? s.Remove(1).ToLower() : s.Remove(1).ToUpper()) + s.Substring(1);
        }
        private static Dictionary<string, Type> GetAllPrimitiveTypes()
        {
            Dictionary<string, Type> aliases = new Dictionary<string, Type>();
            aliases["byte"] = typeof(byte);
            aliases["sbyte"] = typeof(sbyte);
            aliases["short"] = typeof(short);
            aliases["ushort"] = typeof(ushort);
            aliases["int"] = typeof(int);
            aliases["uint"] = typeof(uint);
            aliases["long"] = typeof(long);
            aliases["ulong"] = typeof(ulong);
            aliases["char"] = typeof(char);
            aliases["float"] = typeof(float);
            aliases["double"] = typeof(double);
            aliases["decimal"] = typeof(decimal);
            aliases["bool"] = typeof(bool);
            aliases["object"] = typeof(object);
            aliases["string"] = typeof(string);

            return aliases;
        }
        private static Dictionary<string, string> GetAllExceptionCodes()
        {
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            aliases["ArgumentException"] = "Status400BadRequest";
            aliases["ArgumentNullException"] = "Status400BadRequest";
            aliases["InvalidOperationException"] = "Status400BadRequest";
            aliases["ObjectNotFoundException"] = "Status404NotFound";
            aliases["Exception"] = "Status500InternalServerError";

            return aliases;
        }
    }
}
