using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseGenerator.Helper
{
    internal class TestClassModel
    {
        public string ClassName { get; set; }
        public List<MethodModel> Methods { get; set; }
    }
    internal class MethodModel
    {
        public dynamic ReturnType { get; set; }
        public string MethodName { get; set; }
        public List<ArgumentModel> Arguments { get; set; }
    }

    internal class ArgumentModel
    {
        //Have to cove ref and out params too.
        public dynamic ArgumentType { get; set; }
        public string ArgumentName { get; set; }
    }
}
