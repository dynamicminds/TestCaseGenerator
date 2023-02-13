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
        public List<DataType> Signature { get; set; }
        public List<DataType> Exceptions { get; set; }
        public DataType ReturnValue { get; set; }
    }
}
