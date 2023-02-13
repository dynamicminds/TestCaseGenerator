using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace TestCaseGenerator.Constants
{
    public class MethodParameters
    {
        public string Name { get; set; }
        public DataType Signature { get; set; }
        public DataType Exceptions { get; set; }
        public DataType ReturnValue { get; set; }
    }
}
