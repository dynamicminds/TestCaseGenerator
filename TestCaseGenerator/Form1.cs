using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCaseGenerator.Constants;

namespace TestCaseGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            this.textBox1.Text = openFileDialog1.FileName;

            //UnitTestGenerator.GenerateUnitTests(this.textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //UnitTestGenerator.GenerateUnitTests(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);

            TestGenerator testGenerator = new TestGenerator();
            //FileParameters fileParameters = testGenerator.GenerateDummyFileParameters();
            FileParameters fileParameters = UnitTestGenerator.ParseClassFile(this.textBox1.Text);
            StringBuilder stringBuilder = new StringBuilder();
            int exceptionCtr = 0;
            int loopCtr = 0;
            string testClassName = fileParameters.ClassName + "Tests";
            stringBuilder.AppendLine(UnitTestGenerator.GenerateUnitTestNameSpaces());
            stringBuilder.AppendLine("namespace UnitTestGenerator");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine("   public class " + testClassName);
            stringBuilder.AppendLine("   {");
            stringBuilder.AppendLine(UnitTestGenerator.GenerateUnitTestVariables(fileParameters.ReferencedClassNames, fileParameters.ClassName, 7));
            stringBuilder.AppendLine(UnitTestGenerator.GenerateUnitTestConstructor(fileParameters, testClassName, 7));
            foreach (var methodName in fileParameters.methodParameters)
            {
                exceptionCtr = methodName.Exceptions.Count;
                foreach (var exception in methodName.Exceptions)
                {
                    stringBuilder.Append(testGenerator.GenerateUnitTestArrangeValues(methodName, methodName.ReturnValue.Type, exception.Type, fileParameters.ClassName));
                    stringBuilder.Append('\n');
                    stringBuilder.Append(testGenerator.GenerateUnitTestActValues(methodName, "return", exception.Type));
                    stringBuilder.Append('\n');
                    stringBuilder.Append(testGenerator.GenerateUnitTestAssertValues(methodName, "return", exception.Type));
                    stringBuilder.Append('\n');
                    loopCtr++;
                }
                if (loopCtr == exceptionCtr)
                {
                    stringBuilder.Append(testGenerator.GenerateUnitTestArrangeValues(methodName, methodName.ReturnValue.Type, "OkResult", fileParameters.ClassName));
                    stringBuilder.Append('\n');
                    stringBuilder.Append(testGenerator.GenerateUnitTestActValues(methodName, "return", "OkResult"));
                    stringBuilder.Append('\n');
                    stringBuilder.Append(testGenerator.GenerateUnitTestAssertValues(methodName, "return", "OkResult"));
                    stringBuilder.Append('\n');
                    loopCtr = 0;
                }
            }
            stringBuilder.AppendLine("   }");
            stringBuilder.AppendLine("}");
            stringBuilder.AppendLine("\n");

            // stringBuilder.Append("// End of code");

            var unitTestsContentsPath = this.textBox2.Text + "\\" + this.textBox3.Text + ".cs";
            using (StreamWriter writer = new StreamWriter(unitTestsContentsPath))
            {
                
                writer.WriteLine(stringBuilder.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            this.textBox2.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
