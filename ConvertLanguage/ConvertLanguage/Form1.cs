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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            if (!(stringAnalysis.GetVariables().ConTainArray()))
            {
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
            }
            else
            {
                Variable variableArray = stringAnalysis.GetVariables().GetVariableArray();
                {

                    Color colorVariableName = Color.FromName(variableArray.GetColor());
                    Color colorVariableType = Color.FromName(variableArray.GetColorDataType());
                    AppendText(textInput, variableArray.GetName(), colorVariableName);
                    textInput.AppendText(":");
                    AppendText(textInput, variableArray.GetDataType().Trim(), colorVariableType);
                    textInput.AppendText(",");

                }
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
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                var variableArray = stringAnalysis.GetVariables().GetVariableArray();
                AppendText(textOutput, "ref " + variableArray.GetRealDataType(variableArray.GetDataType()), Color.Blue);
                textOutput.AppendText(" ");
                textOutput.AppendText(variableArray.GetName());

                textOutput.AppendText(",");
            }
            
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
               
                    AppendText(textOutput, Tab(3) + "Console", Color.Cyan);
                    textOutput.AppendText(".WriteLine" + "(" + "\"" + "Nhap " + variable.GetName() + " : " + "\"); " + "\n");
                    textOutput.AppendText(Tab(3) + variable.GetName() + " = ");
                    AppendText(textOutput, variable.GetRealDataType(variable.GetDataType()), Color.Blue);
                    textOutput.AppendText(".Parse(");
                    AppendText(textOutput, "Console", Color.Cyan);
                    textOutput.AppendText(".ReadLine());" + "\n");                
           
            }
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                Variable variable_array = stringAnalysis.GetVariables().GetVariableArray();
                var variables = stringAnalysis.GetVariables();
                AppendText(textOutput, Tab(3)+"for " , Color.Blue);
                textOutput.AppendText("( int i = 0; i < " + variables.GetVariables()[0].GetName()+"; i++ ) \n");
                textOutput.AppendText(Tab(3) + "{" + "\n");

                //Console.WriteLine("Nhap phan tu thu {0}: ",i+1);
                AppendText(textOutput, Tab(4)+"Console", Color.Cyan);
                textOutput.AppendText(".WriteLine(" + "\""+ "Nhap phan tu thu {0} cua mang :" + "\""+ ", i+1 );\n");



                //a[i] = float.Parse(Console.ReadLine());

                textOutput.AppendText(Tab(4) + variable_array.GetName() + "[i] = ");
                AppendText(textOutput, variable_array.GetDataTypeInArray(), Color.Blue);

                textOutput.AppendText(".Parse(");
                AppendText(textOutput, "Console", Color.Cyan);
                textOutput.AppendText(".ReadLine());" + "\n");
                textOutput.AppendText(Tab(3) + "}" + "\n");


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
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                var variableArray = stringAnalysis.GetVariables().GetVariableArray();
                AppendText(textOutput, variableArray.GetRealDataType(variableArray.GetDataType()), Color.Blue);
                textOutput.AppendText(" ");
                textOutput.AppendText(variableArray.GetName());

                textOutput.AppendText(",");
            }
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
                AppendText(textOutput, Tab(3) + "if", Color.Blue);

                textOutput.AppendText(" (" + stringAnalysis.GetPre().GetName() + ") ");
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
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                var variableArray = stringAnalysis.GetVariables().GetVariableArray();
                AppendText(textOutput, " " + variableArray.GetRealDataType(variableArray.GetDataType()), Color.Blue);
                textOutput.AppendText(" ");
                textOutput.AppendText(variableArray.GetName());

                textOutput.AppendText(",");
            }
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
            if (result.GetDataType() != "B")
            {
                AppendText(textOutput, Tab(3) + result.GetRealDataType(result.GetDataType()) + " ", Color.Blue);
                textOutput.AppendText(result.GetName() + result.InitVariable(result.GetDataType()) + "; \n");
            }
            else
            {
                AppendText(textOutput, Tab(3) + result.GetRealDataType(result.GetDataType()) + " ", Color.Blue);

                textOutput.AppendText(result.GetName() + " = true" + "; \n");
            }
        


            //Xu li neu no la loop
            if (post.GetName().Contains("vmith"))
            {
                //string[] splitPre = temp[1].Split(new string[] { "pre" }, StringSplitOptions.None);

                string[] tempPost = post.GetName().Split(new string[] { "vmith{" },StringSplitOptions.None);
                string ForPost = tempPost[1].Split('}')[0];
                string LogicPost = post.GetName().Split(new string[] { "}." }, StringSplitOptions.None)[1];
                LogicPost = LogicPost.Replace("))", ")");
                LogicPost = LogicPost.Replace("(", "[");
                LogicPost = LogicPost.Replace(")", "]");
                bool flag = false;
                if (!flag)
                {
                    LogicPost = LogicPost.Replace("<=", ">");
                    flag = true;
                };
                if (!flag)
                {
                    LogicPost = LogicPost.Replace(">=", "<");
                    flag = true;
                };
                if (!flag)
                {
                    LogicPost = LogicPost.Replace("<", ">=");
                    flag = true;
                };
                if (!flag)
                {
                    LogicPost = LogicPost.Replace(">", "<=");
                    flag = true;
                };


                string[] processForPost = ForPost.Split(new string[] { ".." }, StringSplitOptions.None);
                string indexFirst = processForPost[0];
                string indexLast = processForPost[1];
                //MessageBox.Show(indexFirst+"           "+ indexLast+"             "+LogicPost);
                AppendText(textOutput, Tab(3) +"for", Color.Blue);
                textOutput.AppendText("(");
                AppendText(textOutput, "int ", Color.Blue);


                textOutput.AppendText("i = " + (int.Parse(indexFirst)-1).ToString() + "; i < " + indexLast + ";i++)\n");
                textOutput.AppendText(Tab(3)+"{\n");
                //xu li main
                if (result.GetDataType() == "B")
                {
                    AppendText(textOutput, Tab(4) + "if ", Color.Blue);

                    textOutput.AppendText("(" + LogicPost + ")\n");
                    textOutput.AppendText(Tab(4)+"{ \n");

                    AppendText(textOutput, Tab(5) + "return ", Color.Blue);

                    textOutput.AppendText("false; \n");
                    AppendText(textOutput, Tab(5) + "break;\n ", Color.Blue);
                    AppendText(textOutput, Tab(4) + "}\n ", Color.Blue);

                    textOutput.AppendText(Tab(3) + "}\n");

                }
                else
                {
                    textOutput.AppendText(Tab(4) + LogicPost + ";\n");
                    textOutput.AppendText(Tab(3) +"}\n");

                }



            }
            //Xu li neu no la ham return
            else if (post.IsPostReturn())
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
                    AppendText(textOutput, Tab(3) + "if ", Color.Blue);

                    textOutput.AppendText(post.AnalysisPostNotReturn(f, result.GetName()));
                }



            }
            //return c
            AppendText(textOutput, Tab(3)+ "return ", Color.Blue);
            textOutput.AppendText(result.GetName() + "; \n");
            textOutput.AppendText(Tab(2)+"}" + "\n");

        }
        private void MainFunction()
        {
            //Khai bao bien
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

            if (stringAnalysis.GetVariables().ConTainArray())
            {
                Variable variable_array = stringAnalysis.GetVariables().GetVariableArray();

                AppendText(textOutput, Tab(3)+ variable_array.GetRealDataType(variable_array.GetDataType()) + " ", Color.Blue);

                textOutput.AppendText(variable_array.GetName() + " = ");
                AppendText(textOutput, "new " + variable_array.GetDataTypeInArray(), Color.Blue);
                textOutput.AppendText("[100];\n\n");


            }
            int index = 0;

           
            //Khai bao class

            AppendText(textOutput, Tab(3) + textClassName.Text, Color.Red);
            textOutput.AppendText(" p = ");
            AppendText(textOutput, "new ", Color.Blue);
            AppendText(textOutput, textClassName.Text, Color.Red);
            textOutput.AppendText("();\n");
            textOutput.AppendText(Tab(3)+"p.Nhap_" + stringAnalysis.GetNameFunction().GetName() + "(");
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                var variableArray = stringAnalysis.GetVariables().GetVariableArray();
                AppendText(textOutput, "ref ", Color.Blue);
                textOutput.AppendText(variableArray.GetName());
                textOutput.AppendText(",");
            }
            int index2 = 0;
            foreach (Variable variable in stringAnalysis.GetVariables().GetVariables())
            {
                index2++;
                AppendText(textOutput, "ref ", Color.Blue);
                textOutput.AppendText(variable.GetName());
                if (index2 < stringAnalysis.GetVariables().GetCountVariable())
                {
                    textOutput.AppendText(",");
                }
            }
            textOutput.AppendText(");\n");



            AppendText(textOutput, Tab(3)+"if", Color.Blue);
            textOutput.AppendText("(p.KiemTra_" + stringAnalysis.GetNameFunction().GetName() + "(");
            index = 0;
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                var variableArray = stringAnalysis.GetVariables().GetVariableArray();
                textOutput.AppendText(variableArray.GetName());
                textOutput.AppendText(",");
            }
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
            if (stringAnalysis.GetVariables().ConTainArray())
            {
                var variableArray = stringAnalysis.GetVariables().GetVariableArray();
                textOutput.AppendText(variableArray.GetName());
                textOutput.AppendText(",");
            }
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

        private void textClassName_TextChanged(object sender, EventArgs e)
        {
            if ((textClassName.Text.Contains('0')) || (textClassName.Text.Contains('1')) || (textClassName.Text.Contains('2')) || (textClassName.Text.Contains('3')) || (textClassName.Text.Contains('4')) || (textClassName.Text.Contains('5')) || (textClassName.Text.Contains('6')) || (textClassName.Text.Contains('7')) || (textClassName.Text.Contains('8')) || (textClassName.Text.Contains('9')) || (textClassName.Text.Contains(' ')))
            {
                MessageBox.Show("Không thể nhập số và có khoảng trống");
                textClassName.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textInput.Text = "";
            textClassName.Text = "";
            textOutput.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textInput.Text = "";
            textClassName.Text = "";
            textOutput.Text = "";
        }
    }
}
