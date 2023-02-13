﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseGenerator.Constants
{
    public class FileParamters
    {
        public string InputFileName { get; set; }
        public string OutputFileName { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public string ClassName { get; set; }
        public List<string> ReferencedClassNames { get; set; }
        public List<MethodParameters> methodParameters { get; set; }
    }
}
