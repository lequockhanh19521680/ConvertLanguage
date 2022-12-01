using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertLanguage
{
    public partial class Form1 : Form
    {

        StringAnalysis stringAnalysis;

        public string Tab(int n)
        {
            string result = "";
            for(int i = 0; i < n; i++)
            {
                result += "    ";
            }
            return result;
        }
        public Form1()
        {
            InitializeComponent();
            stringAnalysis = new StringAnalysis();
        }


        private void textOutput_TextChanged(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void RunCs(string code)// just C# 
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = "Application.exe";
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.Count > 0)
            {
                //MessageBox.Show("Lỗi");
            }
            else
            {
                Process.Start(Output);
            }
        }
        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        private void ChangeColorInput()
        {
            string NameFunction = stringAnalysis.GetNameFunction().GetName();
            string stringColorNameFunction = stringAnalysis.GetNameFunction().GetColor();
            Color colorNameFunction = Color.FromName(stringColorNameFunction);


            AppendText(textInput, NameFunction, colorNameFunction);
            textInput.AppendText("(");
            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                Color colorVariableName = Color.FromName(variable.GetColor());
                Color colorVariableType = Color.FromName(variable.GetColorDataType());

                AppendText(textInput, variable.GetName(), colorVariableName);
                textInput.AppendText(":");
                AppendText(textInput, variable.GetDataType().Trim(), colorVariableType);
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textInput.AppendText(",");
                }

            }
            textInput.AppendText(")");

            Variable result = new Variable(stringAnalysis.GetVariables().GetResult().GetName(), stringAnalysis.GetVariables().GetResult().GetDataType());
            Color colorResultName = Color.FromName(result.GetColor());
            Color colorResultType = Color.FromName(result.GetColorDataType());

            AppendText(textInput, result.GetName(), colorResultName);
            textInput.AppendText(":");
            AppendText(textInput, result.GetDataType(), colorResultType);


            Pre preTemp = new Pre(stringAnalysis.GetPre().GetName());
            Post postTemp = new Post(stringAnalysis.GetPost().GetName());

            textInput.AppendText("\n");
            textInput.AppendText("pre ");

            Color colorPre = Color.FromName(preTemp.GetColor());
            Color colorPost = Color.FromName(postTemp.GetColor());

            AppendText(textInput, preTemp.GetName(), colorPre);

            textInput.AppendText("\n");
            textInput.AppendText("post ");
            AppendText(textInput, postTemp.GetName(), colorPost);



        }

        private void DecoderTextInput()
        {
            AppendText(textOutput, "using ", Color.Blue);
            textOutput.AppendText("System;" + "\n");
            AppendText(textOutput, "namespace ", Color.Blue);
            textOutput.AppendText("FormalSpecification" + "\n");
            textOutput.AppendText("{" + "\n");

            AppendText(textOutput, "    public class ", Color.Blue);
            AppendText(textOutput, textClassName.Text + "\n", Color.Red);
            textOutput.AppendText("    {" + "\n");

            NhapText();
            XuatText();
            CheckText();
            ProcessFunctionText();
            MainFunction();
            textOutput.AppendText("    }" + "\n");

            textOutput.AppendText("}");

        }


        private void NhapText()
        {
            AppendText(textOutput, Tab(2) + "public void ", Color.Blue);
            textOutput.AppendText("Nhap_" + stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");

            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                AppendText(textOutput, "ref " + variable.GetRealDataType(variable.GetDataType()), Color.Blue);
                textOutput.AppendText(" ");
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(")" + "\n");
            textOutput.AppendText(Tab(2)+ "{" + "\n");

            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                AppendText(textOutput, Tab(3)+ "Console", Color.Cyan);
                textOutput.AppendText(".WriteLine" + "(" + "\"" + "Nhap " + variable.GetName() + " : " + "\"); " + "\n");
                textOutput.AppendText(Tab(3) + variable.GetName() + " = ");
                AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()), Color.Blue);
                textOutput.AppendText(".Parse(");
                AppendText(textOutput, "Console", Color.Cyan);
                textOutput.AppendText(".ReadLine());" + "\n");
            }
            textOutput.AppendText(Tab(2)+"}" + "\n");
        }



        private void XuatText()
        {
            Variable variable = stringAnalysis.GetVariables().GetResult();

            AppendText(textOutput, Tab(2)+"public void ", Color.Blue);
            textOutput.AppendText("Xuat_" + stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");
            AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()), Color.Blue);
            textOutput.AppendText(" " + variable.GetName() + ")" + "\n");
            textOutput.AppendText(Tab(2)+"{  \n");
            AppendText(textOutput,Tab(3)+ "Console", Color.Cyan);
            textOutput.AppendText(".WriteLine(" + "\"" + "Ket qua la : {0}" + "\"" + "," + variable.GetName() + ");" + "\n");
            textOutput.AppendText(Tab(2)+"}");
            textOutput.AppendText("\n");

        }

        private void CheckText()
        {
            AppendText(textOutput, Tab(2)+"public int ", Color.Blue);
            textOutput.AppendText("KiemTra_" + stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");
            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()) + " ", Color.Blue);
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(")" + "\n");
            textOutput.AppendText(Tab(2)+"{" + "\n");
            //KiemTra2So(int a, int b).....
            string check = stringAnalysis.GetPre().GetName();
            if (check == "")
            {
                AppendText(textOutput, Tab(3)+"return ", Color.Blue);
                textOutput.AppendText("1 ;" + "\n");
            }
            else
            {
                textOutput.AppendText(Tab(3)+"if (" + stringAnalysis.GetPre().GetName() + ") ");
                AppendText(textOutput, "return ", Color.Blue);
                textOutput.AppendText(" 1; \n");
                textOutput.AppendText(Tab(3)+"else ");
                AppendText(textOutput, "return ", Color.Blue);
                textOutput.AppendText("0;" + "\n");
            }
            textOutput.AppendText(Tab(2)+"}" + "\n");
        }

        private void ProcessFunctionText()
        {
            Variable result = stringAnalysis.GetVariables().GetResult();
            Post post = stringAnalysis.GetPost();
            AppendText(textOutput, Tab(2)+"public " + stringAnalysis.GetVariables().GetResult().GetRealDataType(result.GetDataType()) + " ", Color.Blue);
            textOutput.AppendText(stringAnalysis.GetNameFunction().GetName());
            textOutput.AppendText("(");
            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()) + " ", Color.Blue);
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(")" + "\n");
            textOutput.AppendText(Tab(2)+"{" + "\n");
            //float c = 0
            AppendText(textOutput, Tab(3) + result.GetRealDataType(result.GetDataType()) + " ", Color.Blue);

            textOutput.AppendText(result.GetName() + result.InitVariable(result.GetDataType()) + "; \n");
            //Xu li neu no la ham return
            if (post.IsPostReturn())
            {
                string postRemoveFirst = post.GetName().Split('(')[1];
                string postFinally = postRemoveFirst.Split(')')[0];
                textOutput.AppendText(Tab(3)+postFinally+   "; \n");

            }
            else
            {

                string[] processing = post.GetName().Split(new string[] { "||" }, StringSplitOptions.None);
                foreach(string f in processing)
                {
                    textOutput.AppendText(Tab(3) + "if"+post.AnalysisPostNotReturn(f, result.GetName()));
                }



            }
            //return c
            AppendText(textOutput, Tab(3)+ "return ", Color.Blue);
            textOutput.AppendText(result.GetName() + "; \n");
            textOutput.AppendText(Tab(2)+"}" + "\n");

        }


        private void MainFunction()
        {
            AppendText(textOutput, Tab(2)+"public static void ", Color.Blue);
            textOutput.AppendText("Main(");
            AppendText(textOutput, "string[] ", Color.Blue);
            textOutput.AppendText("args)" + "\n");
            textOutput.AppendText(Tab(2)+"{ \n");
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                AppendText(textOutput, Tab(3) + variable.GetRealDataType(variable.GetDataType()) + " ", Color.Blue);
                textOutput.AppendText(variable.GetName() + variable.InitVariable(variable.GetDataType()) + "; \n");
            }
            Variable result = stringAnalysis.GetVariables().GetResult();
            AppendText(textOutput, Tab(3) + result.GetRealDataType(result.GetDataType()) + " ", Color.Blue);
            textOutput.AppendText(result.GetName() + result.InitVariable(result.GetDataType()) + "; \n");
            textOutput.AppendText("\n");

            AppendText(textOutput, Tab(3) + textClassName.Text, Color.Red);
            textOutput.AppendText(" p = ");
            AppendText(textOutput, "new ", Color.Blue);
            AppendText(textOutput, textClassName.Text, Color.Red);
            textOutput.AppendText("();\n");
            textOutput.AppendText(Tab(3)+"p.Nhap_" + stringAnalysis.GetNameFunction().GetName() + "(");

            int index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                AppendText(textOutput, "ref ", Color.Blue);
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(");\n");



            AppendText(textOutput, Tab(3)+"if", Color.Blue);
            textOutput.AppendText("(p.KiemTra_" + stringAnalysis.GetNameFunction().GetName() + "(");
            index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(")==1)\n");



            textOutput.AppendText(Tab(3)+"{ \n");
            textOutput.AppendText(Tab(4) + result.GetName() + " = " + "p." + stringAnalysis.GetNameFunction().GetName() + "(");


            index = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index++;
                textOutput.AppendText(variable.GetName());
                if (index < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText("); \n");
            textOutput.AppendText(Tab(4)+"p.Xuat_" + stringAnalysis.GetNameFunction().GetName() + "(" + result.GetName() + ");\n");
            textOutput.AppendText(Tab(3)+"} \n");
            AppendText(textOutput, Tab(3)+"else ", Color.Blue);
            AppendText(textOutput, "Console", Color.Cyan);
            textOutput.AppendText(".WriteLine(" + "\"" + "Thong tin nhap vao khong hop le " + "\"" + ");\n");
            AppendText(textOutput, Tab(3)+"Console", Color.Cyan);
            textOutput.AppendText(".ReadLine(); \n");

            textOutput.AppendText(Tab(2)+"} \n");
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

   

     

        private void convertBtn_Click_1(object sender, EventArgs e)
        {
            if (convertBtn.Text == "Convert")
            {
                
                    if (textInput.Text == "")
                    {
                        MessageBox.Show("Input bị trống");
                    }
                    else
                    {
                        convertBtn.Text = "Run";
                        DecoderTextInput();
                    }
                
            }
            else if (convertBtn.Text == "Run")
            {
                RunCs(textOutput.Text);
            }
            else
            {
                MessageBox.Show("Lỗi cmnr");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            stringAnalysis.Clear();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                convertBtn.Text = "Convert";
                textInput.Text = File.ReadAllText(openFile.FileName.ToString());
            }

            stringAnalysis.EncoderInputFirst(textInput.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            textInput.Text = "";
            textOutput.Text = "";
            ChangeColorInput();
        }
    }
}
